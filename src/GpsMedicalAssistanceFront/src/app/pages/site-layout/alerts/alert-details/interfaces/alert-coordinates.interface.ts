export interface AlertCoordinates {
    currentLocation: {
        latitude: number,
        longitude: number,
        description: string,
    },
    destinationLocation: {
        latitude: number,
        longitude: number,
        description: string
    }
}
