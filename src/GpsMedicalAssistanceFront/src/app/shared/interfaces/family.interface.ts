import { FamilyType } from "./family-type.interface";
import { User } from "./user.interface";

export interface Family {
    id: number,
    id_User: number,
    id_FamilyType: number,
    name: string,
    lastName: string,
    identification: string,
    phone: string,
    user: User,
    familyType: FamilyType
}