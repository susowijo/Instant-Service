using System.Collections.Generic;
using InstantService.BO;

namespace InstantService.API.Mappings.Contracts.CollectionDetails
{
    /// <summary>
    /// This class represents the model used to retrieve all CollectionDetails
    /// </summary>
    public class CollectionDetailListResponse: BaseResponse
    {
        /// <summary>
        /// Represent a list of CollectionDetail
        /// </summary>
        public virtual ICollection<CollectionDetail> CollectionDetails { get; set; }

        /// <summary>
        /// Represents the number of existing CollectionDetail
        /// </summary>
        public int Count { get; set; }
    }
}