import { config } from "../config";
import { fetchWrapper } from "../utils";

const baseUrl = `${config.VEHICLE_SERVICE_BASEURL}`;

const getCustomers = () => fetchWrapper.get(`${baseUrl}/customers`);

const getVehicles = () => fetchWrapper.get(`${baseUrl}/vehicles`);

const getCustomerVehicles = (customer_id: string) => fetchWrapper.get(`${baseUrl}/customers/${customer_id}/vehicles`);

export const VehicleService = {
    getCustomers,
    getVehicles,
    getCustomerVehicles
};