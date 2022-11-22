import { User } from "src/app/shared/interfaces/user.interface";
import { Alert } from "./alert.interface";
import { UserAnonymous } from "./user-anonymous.interface";

export interface AlertUser {
    id_Alert: number,
    id_User: number | null,
    id_UserAnonymous: number | null,
    id_AlertUserType: number,
    alert: Alert,
    user: User | null,
    userAnonymous: UserAnonymous | null
}
