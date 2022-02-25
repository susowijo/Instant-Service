using System.ComponentModel.DataAnnotations;

namespace InstantService.API.Mappings.Contracts.Users
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRecoverPhoneRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Phone { get; set; }
    }
}