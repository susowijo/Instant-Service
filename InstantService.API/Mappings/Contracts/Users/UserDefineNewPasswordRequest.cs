using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DelenscioUserWebservice.API.Mappings.Contracts;

namespace InstantService.API.Mappings.Contracts.Users
{
    /// <summary>
    /// This class is the model that allows to define a new password
    /// </summary>
    public class UserDefineNewPasswordRequest : BaseRequest
    {
        /// <summary>
        /// Represent the phone number or the email address of the user who wants to define his password when he recovers
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Represents the new password that the user must enter
        /// </summary>
        [Required]
        public string NewPassword { get; set; }

        /// <summary>
        /// Represents the confirm password that the user must enter
        /// </summary>
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
