using System.Collections.Generic;
using InstantService.BO;

namespace InstantService.API.Mappings.Contracts.CollectionTypes
{
    /// <summary>
    /// This class represents the model used to retrieve all CollectionTypes
    /// </summary>
    public class CollectionTypeListResponse: BaseResponse
    {
        /// <summary>
        /// Represent a list of CollectionType
        /// </summary>
        public virtual ICollection<CollectionType> CollectionTypes { get; set; }

        /// <summary>
        /// Represents the number of existing CollectionType
        /// </summary>
        public int Count { get; set; }
    }
}