using KatlaSport.DataAccess.ProductCatalogue;
using KatlaSport.DataAccess.ProductStoreHive;

namespace KatlaSport.DataAccess.ProductStore
{
    /// <summary>
    /// Represent a product requests.
    /// </summary>
    public class StoreItemRequest
    {
        /// <summary>
        /// Gets or sets a product store item request ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product ID.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets a product.
        /// </summary>
        public virtual CatalogueProduct Product { get; set; }

        /// <summary>
        /// Gets or sets a location ID.
        /// </summary>
        public int HiveSectionId { get; set; }

        /// <summary>
        /// Gets or sets a location.
        /// </summary>
        public virtual StoreHiveSection HiveSection { get; set; }

        /// <summary>
        /// Gets or sets a quantity of request items of certain product in the location.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a request is completed.
        /// </summary>
        public bool Completed { get; set; }
    }
}
