using DelenscioUserWebservice.API.Mappings.Contracts;

namespace InstantService.API.Mappings.Contracts.Users
{
    public class SearchUserRequest : BaseRequest
    {
        /// <summary>
        /// Represents the characters with which we want to find the user
        /// </summary>
        public string Name { get; set; }
    }
}