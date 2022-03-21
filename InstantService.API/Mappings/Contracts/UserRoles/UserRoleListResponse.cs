using System.Collections.Generic;
using InstantService.BO;

namespace InstantService.API.Mappings.Contracts.UserRoles
{
    /// <summary>
    /// This class represents the model used to retrieve all UserRoles
    /// </summary>
    public class UserRoleListResponse: BaseResponse
    {
        /// <summary>
        /// Represent a list of UserRole
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Represents the number of existing UserRole
        /// </summary>
        public int Count { get; set; }
    }
}