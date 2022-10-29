import { User } from "src/app/shared/interfaces/user.interface";
import { Alert } from "./alert.interface";

export interface AlertUser {
    id_Alert: number,
    id_User: number,
    id_AlertUserType: number,
    alert: Alert,
    user: User
}
