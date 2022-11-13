import { IncludesGeneral } from "src/app/shared/interfaces/includes-general.interface";

export interface AlertParameters {
    orderBy: number | null,
    name: string | null,
    lastName: string | null,
    identification: string | null,
    identificationType: string | null,
    age: number | null,
    initDate: Date | null,
    endDate: Date | null,
    alertUserTypeId: number | null,
    includes: IncludesGeneral[]
}
