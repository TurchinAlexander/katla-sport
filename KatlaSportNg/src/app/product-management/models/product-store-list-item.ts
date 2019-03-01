import { Product } from "./product"

export class ProductStoreListItem {
    constructor(
        public id: number,
        public product: Product,
        public quantity: number
    ) { }
}