import { AlertUser } from "./alert-user.interface";

export interface Alert {
    id: number,
    currentLocationLatitude: number,
    currentLocationLongitude: number,
    destinationLocationLatitude: number,
    destinationLocationLongitude: number,
    creationDate: Date,
    alertUsers: AlertUser[]
}
