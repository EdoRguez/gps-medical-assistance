import { FamilyCreate } from "./family-create.interface";
import { FavoritePlaceCreate } from "./favorite-place-create.interface";

export interface UserCreate {
    name: string,
    lastName: string,
    email: string,
    identification: string,
    phone: string,
    birthDate: Date | null,
    imagePath: string,
    families: FamilyCreate[],
    favoritePlaces: FavoritePlaceCreate[]
}