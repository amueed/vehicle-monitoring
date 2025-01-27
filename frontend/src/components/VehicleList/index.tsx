import { CheckCircle, Cancel } from "@mui/icons-material";
import { Avatar, Icon, List, ListItem, ListItemAvatar, ListItemText, Typography } from "@mui/material";
import { Vehicle } from "../../models/Vehicle";
import DirectionsBusIcon from '@mui/icons-material/DirectionsBus';

interface VehicleListProps {
    vehicles: Vehicle[]
}

const VehicleList = ({ vehicles }: VehicleListProps) => <List>
    {vehicles.map((item, index) => (
        <ListItem key={index} sx={{
            border: '1px solid #ccc',
            borderRadius: 2,
            marginBottom: 1,
            padding: 1,
        }}>
            <ListItemAvatar>
                <Avatar>
                    <DirectionsBusIcon />
                </Avatar>
            </ListItemAvatar>
            <ListItemText primary={item.vin} secondary={item.registrationNumber} />

            <Icon>
                {item.status === 'online' ? (
                    <CheckCircle color="success" />
                ) : (
                    <Cancel color="error" />
                )}
            </Icon>
            <Typography
                variant="body2"
                color={item.status === 'online' ? 'success' : 'error'}
                sx={{ textTransform: 'capitalize', ml: 1 }}>
                {item.status}
            </Typography>

        </ListItem>
    ))}
</List>

export default VehicleList;