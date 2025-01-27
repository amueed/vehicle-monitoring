using VehicleMonitoring.Core.Domain.Models;

namespace VehicleMonitoring.Api.ViewModels;

public class CustomerViewModel(Guid id, string name)
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;

    public static CustomerViewModel Create(Customer customer)
    {
        ArgumentNullException.ThrowIfNull(customer);
        return new CustomerViewModel(customer.Id, customer.Name);
    }

    public static IEnumerable<CustomerViewModel> Create(IEnumerable<Customer> customers)
    {
        return customers.Select(CustomerViewModel.Create);
    }
}