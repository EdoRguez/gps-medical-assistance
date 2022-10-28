import { IncludesGeneral } from "../../interfaces/includes-general.interface";

export interface UserParameters {
    identificationType: string,
    identification: string,
    includes: IncludesGeneral[]
}