using System.Collections.Generic;
using InstantService.BO;

namespace InstantService.API.Mappings.Contracts.Collections
{
    /// <summary>
    /// This class represents the model used to retrieve all Collections
    /// </summary>
    public class CollectionListResponse: BaseResponse
    {
        /// <summary>
        /// Represent a list of Collection
        /// </summary>
        public virtual ICollection<Collection> Collections { get; set; }

        /// <summary>
        /// Represents the number of existing Collection
        /// </summary>
        public int Count { get; set; }
    }
}