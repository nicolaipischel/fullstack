export interface CreateCaseRequest {
    manifacturer: string,
    hasInsurance: boolean,
    purchaseYear: number,
    isNewCar: boolean,
    price: number,
    paymentType: string,
    productionYear: number
}