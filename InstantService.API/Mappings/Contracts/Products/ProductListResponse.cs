using System.Collections.Generic;
using InstantService.BO;

namespace InstantService.API.Mappings.Contracts.Products
{
    /// <summary>
    /// This class represents the model used to retrieve all Products
    /// </summary>
    public class ProductListResponse: BaseResponse
    {
        /// <summary>
        /// Represent a list of Product
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// Represents the number of existing Product
        /// </summary>
        public int Count { get; set; }
    }
}