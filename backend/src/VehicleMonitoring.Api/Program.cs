var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Seed data on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MonitoringDbContext>();
    DatabaseSeeder.Seed(dbContext);
}

// API Endpoints
app.MapGet("/customers", async (IRepository<Customer> repository) =>
    {
        var customers = await repository.GetAllAsync();
        return CustomerViewModel.Create(customers);
    })
    .WithName("GetCustomers")
    .WithOpenApi();

app.MapGet("/vehicles", async (IRepository<Vehicle> repository, IVehicleStatusService statusService) =>
    {
        var vehicles = await repository.GetAllAsync();
        var vehiclesWithStatus = vehicles.Select(v =>
        {
            var status = statusService.GetStatus(v.Id);
            return VehicleViewModel.Create(v, status);
        });

        return vehiclesWithStatus;
    })
    .WithName("GetVehicles")
    .WithOpenApi();

app.MapGet("/customers/{id:guid}/vehicles",
        async (Guid id, IRepository<Customer> repository, IVehicleStatusService statusService) =>
        {
            var customer = await repository.GetAsync(id, c => c.Vehicles);
            if (customer == null)
                return Results.NotFound();

            var customerVehicles = customer.Vehicles.Select(v =>
            {
                var status = statusService.GetStatus(v.Id);
                return VehicleViewModel.Create(v, status);
            });

            return Results.Ok(customerVehicles);
        })
    .WithName("GetCustomerVehicles")
    .WithOpenApi();

app.Run();