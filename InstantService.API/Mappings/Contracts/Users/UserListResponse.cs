using System.Collections.Generic;
using DelenscioUserWebservice.API.Mappings.Contracts;
using InstantService.BO;

namespace InstantService.API.Mappings.Contracts.Users
{
    /// <summary>
    /// This class represents the model used to retrieve all users
    /// </summary>
    public class UserListResponse: BaseResponse
    {
        /// <summary>
        /// Represent a list of User
        /// </summary>
        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// Represents the number of existing User
        /// </summary>
        public int Count { get; set; }
    }
}