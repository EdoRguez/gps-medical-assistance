import { UserCreate } from "./user-create.interface"

export interface AuthenticationRegister {
    user: UserCreate, 
    password: string
}