using System.ComponentModel.DataAnnotations;
using DelenscioUserWebservice.API.Mappings.Contracts;

namespace InstantService.API.Mappings.Contracts.Users
{
    /// <summary>
    /// This class is the model that allows to define a new password
    /// </summary>
    public class UserVerifySmsCodeRequest : BaseRequest
    {
        /// <summary>
        /// Represent the phone number address of the user who wants to verify code
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Represents the Code that the user must enter
        /// </summary>
        [Required]
        public string Code { get; set; }
    }
}
