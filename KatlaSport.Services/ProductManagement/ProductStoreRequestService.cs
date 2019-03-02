using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStore;
using DbProductStoreRequest = KatlaSport.DataAccess.ProductStore.StoreItemRequest;

namespace KatlaSport.Services.ProductManagement
{
    public class ProductStoreRequestService : IProductStoreRequestService
    {
        private readonly IProductStoreContext _context;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductStoreRequestService"/> class with specified <see cref="IProductStoreContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductStoreContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public ProductStoreRequestService(IProductStoreContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userContext = userContext ?? throw new ArgumentNullException(nameof(UserContext));
        }

        /// <inheritdoc/>
        public async Task<List<ProductStoreItemRequest>> GetRequestsAsync()
        {
            var dbRequests = await _context.Requests.ToArrayAsync();
            var requests = dbRequests.Select(psr => Mapper.Map<ProductStoreItemRequest>(psr)).ToList();

            return requests;
        }

        /// <inheritdoc/>
        public async Task<ProductStoreItemRequest> GetRequestAsync(int requestId)
        {
            var dbRequests = await _context.Requests.Where(r => r.Id == requestId).ToArrayAsync();

            if (dbRequests.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbProductStoreRequest, ProductStoreItemRequest>(dbRequests[0]);
        }

        /// <inheritdoc/>
        public async Task<ProductStoreItemRequest> CreateRequestAsync(UpdateRequestRequest createRequest)
        {
            var dbRequest = Mapper.Map<UpdateRequestRequest, DbProductStoreRequest>(createRequest);
            _context.Requests.Add(dbRequest);

            await _context.SaveChangesAsync();

            return Mapper.Map<ProductStoreItemRequest>(dbRequest);
        }

        /// <inheritdoc/>
        public async Task SetCompletedStatus(int requestId)
        {
            var dbRequests = await _context.Requests.Where(r => r.Id == requestId).ToArrayAsync();

            if (dbRequests.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbRequest = dbRequests[0];
            if (!dbRequest.Completed)
            {
                dbRequest.Completed = true;
                var dbItems = await _context.Items
                    .Where(i => (i.ProductId == dbRequest.ProductId) && (i.HiveSectionId == dbRequest.HiveSectionId))
                    .ToArrayAsync();

                var dbItem = dbItems[0];
                dbItem.Quantity += dbRequest.Quantity;

                await _context.SaveChangesAsync();
            }
        }
    }
}
