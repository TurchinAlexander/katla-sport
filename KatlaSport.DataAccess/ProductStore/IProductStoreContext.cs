namespace KatlaSport.DataAccess.ProductStore
{
    /// <summary>
    /// Represents a context for product store domain.
    /// </summary>
    public interface IProductStoreContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="StoreItem"/> entities.
        /// </summary>
        IEntitySet<StoreItem> Items { get; }

        /// <summary>
        /// Gets a set of <see cref="StoreItemRequest"/> entities.
        /// </summary>
        IEntitySet<StoreItemRequest> Requests { get; }
    }
}