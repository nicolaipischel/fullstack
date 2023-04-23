import { CaseStatus } from "./case-status";

export interface Case {
    id: string,
    description: string,
    status: CaseStatus,
    manifacturer: string,
    model: string,
    hasInsurance: boolean,
    purchaseYear: number,
    purchaseType: string,
    price: number,
    paymentType: string,
    productionYear: number
}