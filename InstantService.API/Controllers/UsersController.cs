using System;
using System.Threading.Tasks;
using AutoMapper;
using DatnekNetSolution.Core.Helpers.Result;
using DatnekNetSolution.Core.Models;
using InstantService.API.BL.Users;
using InstantService.API.Controllers;
using InstantService.API.Mappings.Contracts.Users;
using InstantService.BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace InstantService.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : InstantServiceBaseController<User, UsersController>
    {
        #region Properties (Private)

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<UsersController> _logger;

        /// <summary>
        /// Represent the business logic of the user that will be injected in this controller
        /// </summary>
        private readonly IUserBl _bl;

        /// <summary>
        /// Represent the mapping that will be injected in this controller
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        /// <summary>
        /// Represent the constructor of this class
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="bl">Represent the injection of the user's business logic</param>
        /// <param name="mapper">Represents the mapping injection </param>
        public UsersController(ILogger<UsersController> logger, 
            IUserBl bl, 
            IMapper mapper): base(logger, bl, mapper)
        {
            this._logger = logger;
            this._bl = bl;
            this._mapper = mapper;
        }

        #endregion

        #region Action (Public)

        /// <summary>
        ///     <para>
        ///         This action method allows a user to login
        ///     </para>
        ///     <para>
        ///         Firstly, we check if the model is valid
        ///     </para>
        ///     <para>
        ///         If the model is valid, we get the user loger and in a second step, we check if the user is null or not and 
        ///         if the model in not valid we return badRequest.
        ///     </para>
        /// </summary>
        /// <param name="userLogin">Represent the model allowing the connection of a user</param>
        /// <response code="200">If the user is not null, we return it</response>
        /// <response code="400">If the User is null we return not found</response>
        /// <returns></returns>
        [HttpPost("Login")]
        public Task<BaseHttpResponse<User>> LoginAsync([FromBody] UserLoginRequest userLogin)
            => ExecuteBlAsync(() => _bl.LoginAsync(userLogin));
        
        /// <summary>
        ///     <para>
        ///         This action method allows a user to log out
        ///     </para>
        ///     <para>
        ///         In this action method we return the user disconnected if everything went well and the statusCode = 200 
        ///         otherwise we return the error message and the status code = 400
        ///     </para>
        /// </summary>
        /// <param name="id">Represent the identifier of the user who wants to log out</param>
        /// <response code="200">If the user is not null, we return it</response>
        /// <response code="400">If the User is null we return not found</response>
        /// <returns></returns>
        [HttpPost("Logout/{id}")]
        public  Task<BaseHttpResponse<User>> LogoutAsync(Guid? id)
            => ExecuteBlAsync(() => _bl.LogoutAsync(id));
        

        /// <summary>
        ///     <para>
        ///         This action method allows you to send an email to the user 
        ///         containing the confirmation code of the email address
        ///     </para>
        ///     <para>
        ///         In this action method, we return the user to whom the email was sent 
        ///         if everything went well and the statusCode = 200 
        ///         otherwise we return the error message and the status code = 400
        ///     </para>
        /// </summary>
        /// <param name="id">
        ///     Represent the identifier of the user who will receive his confirmation code from his email address
        /// </param>
        /// <response code="200">If the user is not null, we return it</response>
        /// <response code="400">If the User is null we return not found</response>
        /// <returns></returns>
        [HttpPost("SendCodeConfirmEmail/{id}")]
        public  Task<BaseHttpResponse<User>> SendingTheCodeVerificationEmailAddressAsync(Guid? id)
            => ExecuteBlAsync(() => _bl.SendingTheCodeVerificationEmailAddressAsync(id));
        
        /// <summary>
        ///     <para>
        ///         This action method allows to send an email to the user containing 
        ///         the link that he will follow to recover his password
        ///     </para>
        ///     <para>
        ///         In this action method, we return the user to whom the email was sent
        ///         if everything went well and the statusCode = 200 
        ///         otherwise we return the error message and the status code = 400
        ///     </para>
        /// </summary>
        /// <param name="model">
        ///     Represent the email address of the user who will receive the link for the recovery of his password
        /// </param>
        /// <response code="200">If everything went well, we return User</response>
        /// <response code="400">If the User is null we return not found</response>
        /// <returns></returns>
        [HttpPost("SendLinkByEmailAddress")]
        public  Task<BaseHttpResponse<User>> SendingPasswordRecoveryLinkByEmailAsync([FromBody] UserRecoverEmailRequest model)
            => ExecuteBlAsync(() => _bl.SendingPasswordRecoveryLinkByEmailAsync(model.Email, model.ResetLink));
        
        /// <summary>
        ///     <para>
        ///         This action method allows to send a message (SMS) to the user 
        ///         containing the code he will use to recover his password
        ///     </para>
        ///     <para>
        ///         In this action method, we return the user to whom the message has been sent
        ///         if everything went well and the statusCode = 200 
        ///         otherwise we return the error message and the status code = 400
        ///     </para>
        /// </summary>
        /// <param name="model">
        ///     Represent the phone number of the user who will receive the message (SMS) for the recovery of his password
        /// </param>
        /// <response code="200">If everything went well, we return User</response>
        /// <response code="400">If the User is null we return not found</response>
        /// <returns></returns>
        [HttpPost("SendCodeBySms")]
        public  Task<BaseHttpResponse<User>> SendingPasswordRecoveryCodeBySmsAsync([FromBody] UserRecoverPhoneRequest model)
            => ExecuteBlAsync(() => _bl.SendingPasswordRecoveryCodeBySmsAsync(model.Phone));
       
        /// <summary>
        ///     <para>
        ///         This action method allows a user to confirm his email address with the code he received in his mailbox
        ///     </para>
        ///     <para>
        ///         In this action method, we return the user to whom the confirm his email address
        ///         if everything went well and the statusCode = 200 
        ///         otherwise we return the error message and the status code = 400
        ///     </para>
        /// </summary>
        /// <param name="id">
        ///     Represents the code that the user received in his mailbox
        /// </param>
        /// <param name="confirm">
        ///     Repr�sente le code que l'utilisateur a re�u dans sa boite mail
        /// </param>
        /// <response code="200">If everything went well, we return User</response>
        /// <response code="400">If the User is null we return not found</response>
        /// <returns></returns>
        [HttpPost("ConfirmEmail/{id}")]
        public  Task<BaseHttpResponse<User>> VerifyEmailAddressAsync(Guid? id, [FromBody] UserConfirmEmailRequest confirm)
            => ExecuteBlAsync(() => _bl.VerificationEmailAddressAsync(id, confirm.Code));

        /// <summary>
        ///     <para>
        ///         This action method allows you to retrieve a user from his email address
        ///     </para>
        ///     <para>
        ///         In this action method, we return the user from his email address
        ///         if everything went well and the statusCode = 200 
        ///         otherwise we return the error message and the status code = 400
        ///     </para>
        /// </summary>
        /// <param name="emailAddress">Represent the user's email</param>
        /// <response code = "200">Returns the user that matches the specified email address</response>
        /// <response code = "400">Returns not Found if the email address does not correspond to a user</response>
        [HttpGet("GetUserByEmail/{emailAddress}")]
        public  Task<BaseHttpResponse<User>> GetUserByEmailAddressAsync(string emailAddress)
            => ExecuteBlAsync(() => _bl.GetUserByEmailAddressAsync(emailAddress));
        
        /// <summary>
        ///     <para>
        ///         This action method allows you to retrieve a user from his phone number
        ///     </para>
        ///     <para>
        ///         In this action method, we return the user from his phone number
        ///         if everything went well and the statusCode = 200 
        ///         otherwise we return the error message and the status code = 400
        ///     </para>
        /// </summary>
        /// <param name="model">Represent the user's phone number</param>
        /// <response code = "200">Returns the user that matches the specified phone number</response>
        /// <response code = "400">Returns not Found if the phone number does not correspond to a user</response>
        [HttpPost("GetUserByPhoneNumber")]
        public  Task<BaseHttpResponse<User>> GetUserByPhoneNumberAsync([FromBody] UserRecoverPhoneRequest model)
            => ExecuteBlAsync(() => _bl.GetUserByPhoneNumberAsync(model.Phone));

        /// <summary>
        ///     <para>
        ///         This action method allows to define a new password from the model passed in paramete
        ///     </para>
        ///     <para>
        ///         In this action method we return the user whose pasword has been modified
        ///         if everything went well and the statusCode = 200 
        ///         otherwise we return the error message and the status code = 400
        ///     </para>
        /// </summary>
        /// <param name="request">Represent the model that allows to define a new pasword</param>
        /// <response code="200">If everything went well, we return User</response>
        /// <response code="400">If the User is null we return not found</response>
        [HttpPost("DefineNewPassword")]
        public  Task<BaseHttpResponse<User>> DefineNewPasswordAsync([FromBody] UserDefineNewPasswordRequest request)
            => ExecuteBlAsync(() => _bl.DefineNewPasswordAsync(request));

        /// <summary>
        ///     <para>
        ///         This action method allows to check the code concerning the recovery of the password by sms
        ///     </para>
        ///     <para>
        ///         In this action method we return the user if the code concerning the recovery of the password by sms is verified
        ///         if everything went well and the statusCode = 200 
        ///         otherwise we return the error message and the status code = 400
        ///     </para>
        /// </summary>
        /// <param name="request">Represents the model that allows the verification of the code for the recovery of the password by sms</param>
        /// <response code="200">If everything went well, we return user</response>
        /// <response code="400">If the User is null we return not found</response>
        [HttpPost("VerifyCode")]
        public  Task<BaseHttpResponse<User>> VerifyCodeToPasswordRecoveryBySmsAsync([FromBody] UserVerifySmsCodeRequest request)
            => ExecuteBlAsync(() => _bl.VerifyCodeToPasswordRecoveryBySmsAsync(request));

        /// <summary>
        ///     Get all users whose name includes these characters entered in parameter
        /// </summary>
        /// <remarks>
        ///     ## Percompany ##
        ///     Website user
        ///     ## Description ##
        ///     This API is used in the element details to display a list of all 
        ///     available user whose name includes these characters entered in parameter
        ///     ## Example ##
        ///     ```
        ///     Get ByName
        ///     ```
        ///     *Get all users whose name includes these characters entered in parameter.*
        /// </remarks>
        /// <response code="200">
        ///     **Success** - The users are recovered.
        ///     **Unexcepted** - An unexecepted error occurs.
        /// </response>
        /// <response code="401">
        ///     The user is not authenticated 
        /// </response>
        /// <response code="403">
        ///     The user has not the right to get Get all user whose name includes these characters entered in parameter
        /// </response>
        /// <param name="request">The characters with which we want to find the user</param>
        /// <returns></returns>
        [HttpPost("ByName")]
        public Task<BaseHttpResponse<ListResult<User>>> GetUserByName([FromBody] SearchUserRequest request)
            => ExecuteBlAsync(() => _bl.GetUserByNameAsync(request));

        #endregion

        #region Methodes (Public)


        #endregion

        #region Methodes (Public)


        #endregion
    }
}