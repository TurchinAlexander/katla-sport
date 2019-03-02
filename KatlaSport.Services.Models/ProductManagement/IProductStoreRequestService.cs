using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product store request service.
    /// </summary>
    public interface IProductStoreRequestService
    {
        /// <summary>
        /// Get a list of requests of product stores.
        /// </summary>
        /// <returns><see cref="Task{List{ProductStoreItemRequest}}"/>.</returns>
        Task<List<ProductStoreItemRequest>> GetRequestsAsync();

        /// <summary>
        /// Get a product store request.
        /// </summary>
        /// <param name="requestId">A product store request id.</param>
        /// <returns>A <see cref="Task{ProductStoreItemRequest}"/></returns>
        Task<ProductStoreItemRequest> GetRequestAsync(int requestId);

        /// <summary>
        /// Creates a new product store request.
        /// </summary>
        /// <param name="createRequest">A <see cref="Update"/>.</param>
        /// <returns>A <see cref="Task{ProductStoreItemRequest}">.</returns>
        Task<ProductStoreItemRequest> CreateRequestAsync(UpdateRequestRequest createRequest);

        /// <summary>
        /// Sets completed status for a product store request.
        /// </summary>
        /// <param name="requestId">A product store request id.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task SetCompletedStatus(int requestId);
    }
}
