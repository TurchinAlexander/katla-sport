using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductStore
{
    public class StoreItemRequestConfiguration : EntityTypeConfiguration<StoreItemRequest>
    {
        public StoreItemRequestConfiguration()
        {
            ToTable("product_store_item_requests");
            HasKey(i => i.Id);
            HasRequired(i => i.Product).WithMany(i => i.Requests).HasForeignKey(i => i.ProductId);
            HasRequired(i => i.HiveSection).WithMany(i => i.Requests).HasForeignKey(i => i.HiveSectionId);
            Property(i => i.Id).HasColumnName("product_store_item_request_id");
            Property(i => i.Quantity).HasColumnName("product_store_item_request_quantity");
            Property(i => i.HiveSectionId).HasColumnName("product_store_item_request_hive_section_id");
            Property(i => i.ProductId).HasColumnName("product_store_item_request_product_id");
            Property(i => i.Completed).HasColumnName("product_store_item_request_completed");
        }
    }
}
