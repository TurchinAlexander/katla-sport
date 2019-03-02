export class ProductStoreItemRequest {
    constructor(
        public id: number,
        public productId: number,
        public hiveSectionId: number,
        public quantity: number,
        public completed: boolean
    ) { }
}