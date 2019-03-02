namespace KatlaSport.Services.ProductManagement
{
    public class ProductStoreItemRequest
    {
        /// <summary>
        /// Gets or sets the product store request identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the hive section id.
        /// </summary>
        public int HiveSectionId { get; set; }

        /// <summary>
        /// Gets or sets a quantity of the product in the request.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the request is completed.
        /// </summary>
        public bool Completed { get; set; }
    }
}
