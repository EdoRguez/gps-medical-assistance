import { User } from "./user.interface";

export interface FavoritePlace {
    id: number,
    id_User: number,
    name: string,
    latitude: number,
    longitude: number,
    user: User
}