using System.Collections.Generic;
using InstantService.BO;

namespace InstantService.API.Mappings.Contracts.RolePermissions
{
    /// <summary>
    /// This class represents the model used to retrieve all RolePermissions
    /// </summary>
    public class RolePermissionListResponse: BaseResponse
    {
        /// <summary>
        /// Represent a list of RolePermission
        /// </summary>
        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        /// <summary>
        /// Represents the number of existing RolePermission
        /// </summary>
        public int Count { get; set; }
    }
}