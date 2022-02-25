using System.ComponentModel.DataAnnotations;
using DelenscioUserWebservice.API.Mappings.Contracts;

namespace InstantService.API.Mappings.Contracts.Users
{
    /// <summary>
    /// This class represents the model used to connect
    /// </summary>
    public class UserLoginRequest: BaseRequest
    {
        // Reference Value (int, float, string)
        //  Reference = nummlable non nullable 
        /// <summary>
        /// Represents the email that the user enters to connect
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Represent the password that the user enters to connect
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}