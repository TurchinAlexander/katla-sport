namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represent a product in hive section.
    /// </summary>
    public class ProductStoreListItem
    {
        /// <summary>
        /// Gets or sets a product store identifier.
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
        /// Gets or sets a quantity of product.
        /// </summary>
        public int Quantity { get; set; }
    }
}
