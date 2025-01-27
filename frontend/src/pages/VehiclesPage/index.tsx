import { useEffect, useState } from "react";
import './style.scss';
import { VehicleService } from "../../services";
import { Customer } from "../../models/Customer";
import { Vehicle } from "../../models/Vehicle";
import { Box, MenuItem, Select, Typography } from "@mui/material";
import VehicleList from "../../components/VehicleList";

const VehiclesPage = () => {
    const [customers, setCustomers] = useState<Customer[]>([]);
    const [vehicles, setVehicles] = useState<Vehicle[]>([]);
    const [selectedCustomer, setSelectedCustomer] = useState("0");

    useEffect(() => {
        const fetchCustomers = () => VehicleService.getCustomers().then(data => setCustomers(data));
        const fetchVehicles = async () => VehicleService.getVehicles().then(data => setVehicles(data));

        fetchCustomers();
        fetchVehicles();
    }, []);

    const onChangeCustomer = (e: any) => {
        const customerId = e.target.value;
        setSelectedCustomer(customerId);
        if (customerId != 0) {
            VehicleService.getCustomerVehicles(customerId).then(data => setVehicles(data));
        } else {
            VehicleService.getVehicles().then(data => setVehicles(data));
        }
    }

    return (
        <Box>
            <Typography variant="h4" mt={2} mb={2}>
                Vehicle Monitoring
            </Typography>
            <Box>
                <Select
                    sx={{ width: 250 }}
                    onChange={onChangeCustomer}
                    value={selectedCustomer}
                >
                    <MenuItem value="0">All Customers</MenuItem>
                    {customers.map(c =>
                        <MenuItem value={c.id}>{c.name}</MenuItem>
                    )}
                </Select>
            </Box>

            <Box
                sx={{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                }}
                mt={2}
            >
                <Box sx={{
                    width: '100%', maxWidth: 500,
                }}>
                    <VehicleList vehicles={vehicles} />
                </Box >
            </Box>
        </Box >
    );
};
export default VehiclesPage;