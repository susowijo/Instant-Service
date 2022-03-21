using System.Collections.Generic;
using InstantService.BO;

namespace InstantService.API.Mappings.Contracts.Roles
{
    /// <summary>
    /// This class represents the model used to retrieve all Roles
    /// </summary>
    public class RoleListResponse: BaseResponse
    {
        /// <summary>
        /// Represent a list of Role
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// Represents the number of existing Role
        /// </summary>
        public int Count { get; set; }
    }
}