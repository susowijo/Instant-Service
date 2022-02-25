using System;
using System.Threading.Tasks;
using DatnekNetSolution.Core.Helpers.Result;
using DatnekNetSolution.Core.Models;
using InstantService.API.DAL.Repositories.Users;
using InstantService.API.Mappings.Contracts.Users;
using InstantService.BO;

namespace InstantService.API.BL.Users
{
    /// <summary>
    /// This class defines the methods that consume the services 
    /// of DatnekNetSolution for a better user management 
    /// and these methods will be implemented in the UserBl class
    /// </summary>
    public interface IUserBl : IUserRepository
    {
        #region Methode (Public)

        /// <summary>
        ///     <para>
        ///         This method sends an email to the user containing the confirmation code of his email address
        ///     </para>
        ///     <para>
        ///         It takes as parameter the user's ID
        ///     </para>
        /// </summary>
        /// <param name="userId">Represent the identifier of the user who wants to check his email address</param>
        /// <returns></returns>
        Task<BaseResult<User>> SendingTheCodeVerificationEmailAddressAsync(Guid? userId);

        /// <summary>
        ///     <para>
        ///         This method sends an e-mail to the user containing the code to recover his password.
        ///     </para>
        ///     <para>
        ///         It takes the user's email address as parameter
        ///     </para>
        /// </summary>
        /// <param name="email">Represent the email address of the user who wants to retrieve his password by email</param>
        /// <param name="resetLink">Represent new redirection link</param>
        /// <returns></returns>
        Task<BaseResult<User>> SendingPasswordRecoveryLinkByEmailAsync(string email, string resetLink);

        /// <summary>
        ///     <para>
        ///         This method sends a message (SMS) to the user containing the code to recover his password
        ///     </para>
        ///     <para>
        ///         It takes as parameter the user's phone number
        ///     </para>
        /// </summary>
        /// <param name="phoneNumber">Represent the number of the user who wants to retrieve his password by message (SMS)</param>
        /// <returns></returns>
        Task<BaseResult<User>> SendingPasswordRecoveryCodeBySmsAsync(string phoneNumber);

        /// <summary>
        ///     <para>
        ///         This method allows the user to confirm his email address
        ///     </para>
        ///     <para>
        ///         It takes as parameters the user's identifier and the code that the user must enter
        ///     </para>
        /// </summary>
        /// <param name="userId">Represent the identifier of the user who wants to check his email address</param>
        /// <param name="code">Represent the code that the user must enter to verify his email address</param>
        /// <returns></returns>
        Task<BaseResult<User>> VerificationEmailAddressAsync(Guid? userId, string code);

        /// <summary>
        ///     <para>
        ///         This method allows you to retrieve a user from his email address
        ///     </para>
        ///     <para>
        ///         It takes the user's email address as parameter
        ///     </para>
        /// </summary>
        /// <param name="emailAddress">Represent the email address to enter to search for the user</param>
        /// <returns></returns>
        Task<BaseResult<User>> GetUserByEmailAddressAsync(string emailAddress);

        /// <summary>
        ///     <para>
        ///         This method allows you to retrieve a user from his phone number
        ///     </para>
        ///     <para>
        ///         It takes the user's phone number as parameter
        ///     </para>
        /// </summary>
        /// <param name="phoneNumber">Represent the phone number to enter to perform the search for the user</param>
        /// <returns></returns>
        Task<BaseResult<User>> GetUserByPhoneNumberAsync(string phoneNumber);

        /// <summary>
        ///     <para>
        ///         This method allows you to set a new password
        ///     </para>
        /// </summary>
        /// <param name="request">Represent the model that allows to define a new pasword</param>
        /// <returns></returns>
        Task<BaseResult<User>> DefineNewPasswordAsync(UserDefineNewPasswordRequest request);

        /// <summary>
        ///     <para>
        ///         This method allows to check the password recovery code by sms
        ///     </para>
        /// </summary>
        /// <param name="request">Represents the model that allows the verification of the code for the recovery of the password by sms</param>
        /// <returns></returns>
        Task<BaseResult<User>> VerifyCodeToPasswordRecoveryBySmsAsync(UserVerifySmsCodeRequest request);

        #endregion
    }
}