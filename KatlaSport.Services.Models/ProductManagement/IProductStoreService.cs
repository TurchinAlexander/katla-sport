using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product store service.
    /// </summary>
    public interface IProductStoreService
    {
        /// <summary>
        /// Get a list of products in hive section.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <returns><see cref="Task{List{ProductStoreListItem}}"/></returns>
        Task<List<ProductStoreListItem>> GetProductStoreItemsAsync(int hiveSectionId);
    }
}
