using FluentValidation.Attributes;

namespace KatlaSport.Services.ProductManagement
{
    /// <summary>
    /// Represents a request for creating and updating a product store request.
    /// </summary>
    [Validator(typeof(UpdateRequestRequestValidator))]
    public class UpdateRequestRequest
    {
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
    }
}
