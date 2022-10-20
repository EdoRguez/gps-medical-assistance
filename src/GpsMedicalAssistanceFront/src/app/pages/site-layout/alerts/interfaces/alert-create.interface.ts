import { AlertUserCreate } from "./alert-user-create.interface";

export interface AlertCreate {
    currentLocationLatitude: number,
    currentLocationLongitude: number,
    destinationLocationLatitude: number,
    destinationLocationLongitude: number,
    alertUsers : AlertUserCreate[]
}