import { Family } from "./family.interface";
import { FavoritePlace } from "./favorite-place.interface";

export interface User {
    id: number,
    name: string,
    lastName: string,
    email: string,
    identification: string,
    phone: string,
    birthDate: Date,
    imagePath: string,
    families: Family[],
    favoritePlaces: FavoritePlace[]
}