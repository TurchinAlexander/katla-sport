using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductStore;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a product store service.
    /// </summary>
    public class ProductStoreService : IProductStoreService
    {
        private readonly IProductStoreContext _context;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductStoreService"/> class with specified <see cref="IProductStoreContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductStoreContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public ProductStoreService(IProductStoreContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userContext = userContext ?? throw new ArgumentNullException(nameof(UserContext));
        }

        /// <inheritdoc/>
        public async Task<List<ProductStoreListItem>> GetProductStoreItemsAsync(int hiveSectionId)
        {
            var dbProductStores = await _context.Items.Where(ps => ps.HiveSectionId == hiveSectionId).ToArrayAsync();
            var productStores = dbProductStores.Select(ps => Mapper.Map<ProductStoreListItem>(ps)).ToList();

            return productStores;
        }
    }
}
