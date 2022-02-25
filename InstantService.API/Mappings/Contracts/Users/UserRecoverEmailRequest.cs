namespace InstantService.API.Mappings.Contracts.Users
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRecoverEmailRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ResetLink { get; set; }
    }
}