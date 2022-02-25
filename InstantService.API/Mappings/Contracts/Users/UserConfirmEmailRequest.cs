using System.ComponentModel.DataAnnotations;

namespace InstantService.API.Mappings.Contracts.Users
{
    /// <summary>
    /// Class confirm email
    /// </summary>
    public class UserConfirmEmailRequest
    {
        /// <summary>
        /// Get and set code
        /// </summary>
        [Required]
        public string Code { get; set; }
    }
}