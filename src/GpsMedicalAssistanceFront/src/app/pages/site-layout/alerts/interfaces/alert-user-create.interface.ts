import { UserAnonymousCreate } from "./user-anonymous-create.interface";

export interface AlertUserCreate {
    id_User: number | null,
    userAnonymous: UserAnonymousCreate | null,
    id_AlertUserType: number,
}
