using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatnekNetSolution.Core.Extension;
using DatnekNetSolution.Core.Helpers.Result;
using DatnekNetSolution.Core.Models;
using DatnekNetSolution.Core.Services.Ftp;
using DatnekNetSolution.Core.Services.Mailling;
using DatnekNetSolution.Core.Services.Sms;
using InstantService.API.BL.Users;
using InstantService.API.DAL;
using InstantService.API.DAL.Repositories.Users;
using InstantService.API.Mappings.Contracts.Users;
using InstantService.API.Services.Utils;
using InstantService.BO;
using Microsoft.EntityFrameworkCore;

namespace InstantService.API.BL.Users
{
    public class UserBl: UserRepository, IUserBl
    {
        #region Properties (Private)

        /// <summary>
        /// Represent the DatnekNetSolution email service that will be injected into this controller
        /// </summary>
        private readonly IMailingService _mailingService;

        /// <summary>
        /// Represent the service of sending messages (SMS) from DatnekNetSolution that will be injected into this controller
        /// </summary>
        private readonly ISmsService _smsService;

        /// <summary>
        /// Represent the context of the application that will be injected into this controller
        /// </summary>
        private readonly InstantServiceContext _context;
        
        /// <summary>
        /// Manage file
        /// </summary>
        private readonly IFtpManageFileService _ftpManageFileService;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Represents the constructor of this class
        /// </summary>
        /// <param name="context">Represent the context injection</param>
        /// <param name="mailingService">Represent the service injection of the mails</param>
        /// <param name="smsService">Represent the service injection of the Sms</param>
        /// <param name="ftpManageFileService"></param>
        public UserBl(InstantServiceContext context, 
            IMailingService mailingService, ISmsService smsService,
            IFtpManageFileService ftpManageFileService) :
            base(context)
        {
            _context = context;
            _mailingService = mailingService;
            _smsService = smsService;
            _ftpManageFileService = ftpManageFileService;
        }

        #endregion

        #region Methode (Public)


        /// <summary>
        ///     <para>
        ///         This method sends an email to the user containing the confirmation code of his email address
        ///     </para>
        ///     <para>
        ///         It takes as parameter the user's ID
        ///     </para>
        ///     <para>
        ///         Firstly we search for the user from id
        ///     </para>
        ///     <para>
        ///         Then if the user exists, his confirmation code of his email address is generated and we send him by email 
        ///         and we return him (the user) otherwise we report that he has not been found
        ///     </para>
        /// </summary>
        /// <param name="userId">Represent the identifier of the user who wants to check his email address</param>
        /// <returns></returns>
        public async Task<BaseResult<User>> SendingTheCodeVerificationEmailAddressAsync(Guid? userId)
        {
           var result = await GetAsync(userId);
           
            if(result.IsSuccess){
                string fullName = $"{result.Data.FirstName} {result.Data.LastName}";
                string codeFirstPart = result.Data.CodeConfirm?.Substring(0, 3);
                string codeSecondPart = result.Data.CodeConfirm?.Substring(3);

                if(result.Data.Email != null)
                    _mailingService.Send
                    (
                        fullName,
                        result.Data.Email,
                        "Confirmation of your e-mail address",
                        UtilService.GetData("registration_email_code.html"),
                        new List<KeyValue>()
                        {
                            new KeyValue("CodeFirstPart", codeFirstPart),
                            new KeyValue("CodeSecondPart", codeSecondPart)
                        },
                        true
                    );

                return result;
            }
            return new BaseResult<User>(BaseResultStatus.NotFound, new Exception("User not found"));
        }

        /// <summary>
        ///     <para>
        ///         This method allows the user to confirm his email address
        ///     </para>
        ///     <para>
        ///         It takes as parameters the user's identifier and the code that the user must enter
        ///     </para>
        ///     <para>
        ///         Firstly we search for the user from id
        ///     </para>
        ///     <para>
        ///         Secondly, if the user exists, we check the confirmation code registered in the database 
        ///         with the one that the user has entered 
        ///     </para>
        ///     <para>
        ///         Then, if the two codes are identical, we change the values of the fields :
        ///         Isconnected to true, 
        ///         EmailConfirm to true 
        ///         and we update the user then we return this user
        ///     </para>
        ///     <para>
        ///         finally, if the two codes are not identical, we review a message and 
        ///         if the user has not been found, we report it
        ///     </para>
        /// </summary>
        /// <param name="userId">Represent the identifier of the user who wants to check his email address</param>
        /// <param name="code">Represent the code that the user must enter to verify his email address</param>
        /// <returns></returns>
        public async Task<BaseResult<User>> VerificationEmailAddressAsync(Guid? userId, string code)
        {
            var result = await GetAsync(userId);

            if (result.IsSuccess)
            {
                if (result.Data.CodeConfirm == code)
                {
                    result.Data.Isconnected = true;
                    result.Data.EmailConfirm = true;
                    result.Data.CodeConfirm = null;
                    result.Data.StepRegistration = BO.Helpers.Enum.StepEnum.STEPTREE;
                    return await UpdateAsync(result.Data);
                }
                return new BaseResult<User>(BaseResultStatus.NotFound, new Exception("Please check your email and typing good code"));
            }

            return new BaseResult<User>(BaseResultStatus.NotFound, new Exception("User not found"));
        }

        /// <summary>
        ///     <para>
        ///         This method sends an e-mail to the user containing the code to recover his password.
        ///     </para>
        ///     <para>
        ///         It takes the user's email address as parameter
        ///     </para>
        ///     <para>
        ///         Firstly we search for the user from the entered email address
        ///     </para>
        ///     <para>
        ///         Secondly, if the user exists, we send him a link in his mailbox that he will follow  and 
        ///         we return him (the user) otherwise we report that he has not been found
        ///     </para>
        /// </summary>
        /// <param name="email">Represent the email address of the user who wants to retrieve his password by email</param>
        /// <param name="resetLink">Represent new redirection link</param>
        /// <returns></returns>
        public async Task<BaseResult<User>> SendingPasswordRecoveryLinkByEmailAsync(string email, string resetLink)
        {
            var result = await GetUserByEmailAddressAsync(email);

            if (result.IsSuccess)
            {
                string code = UtilService.GenerateUniqueCode().Hash();

                string fullName = $"{result.Data.FirstName} {result.Data.LastName}";

                _mailingService.Send
                (
                    fullName, 
                    email?? String.Empty, 
                    "Password recovery", 
                    UtilService.GetData("password_recovery_email_code.html"),
                    new List<KeyValue>()
                    {
                        new KeyValue("Code", code),
                        new KeyValue("Email", email),
                        new KeyValue("ResetLink", resetLink)
                    },
                    true
                );

                result.Data.CodeConfirm = code;

                return await UpdateAsync(result.Data);
            }

            return new BaseResult<User>(BaseResultStatus.NotFound, new Exception("User not found"));
        }

        /// <summary>
        ///     <para>
        ///         This method sends a message (SMS) to the user containing the code to recover his password
        ///     </para>
        ///     <para>
        ///         It takes as parameter the user's phone number
        ///     </para>
        ///     <para>
        ///         Firstly we search for the user from the entered phone number
        ///     </para>
        ///     <para>
        ///         Then if the user exists, we generate his password recovery code and store it in the database, 
        ///         then we send it by message (SMS), we update the user 
        ///         and we return him (the user) otherwise we report that "User not found"
        ///     </para>
        /// </summary>
        /// <param name="phoneNumber">Represent the number of the user who wants to retrieve his password by message (SMS)</param>
        /// <returns></returns>
        public async Task<BaseResult<User>> SendingPasswordRecoveryCodeBySmsAsync(string phoneNumber)
        {
            var result = await SearchOneByByAsync(user => user.PhoneNumber == phoneNumber);

            if (result.IsSuccess)
            {
                string code = UtilService.GenerateUniqueCode();

                var response = await _smsService.SendAsyc(new[] { phoneNumber }, $"Password recovery code : {code} ");

                if (response != null)
                {
                    result.Data.CodeConfirm = code;

                   return await UpdateAsync(result.Data);
                }

                return new BaseResult<User>(BaseResultStatus.BadParams, new Exception("send code fail"));
            }
            return new BaseResult<User>(BaseResultStatus.NotFound, new Exception("User not found"));
        }

        /// <summary>
        ///     <para>
        ///         This method returns a user from his entered email address
        ///     </para>
        ///     <para>
        ///         It takes the user's email address as parameter 
        ///     </para>
        ///     <para>
        ///         First we search the user with the mail he entered and the result is contained in the user varriable.
        ///     </para>
        ///     <para>
        ///         And at the end we check the user variable if it's not null we return the user 
        ///         and if it's null we return the message "User not found"
        ///     </para>
        /// </summary>
        /// <param name="email">Represent the email address to enter to search for the user</param>
        /// <returns></returns>
        public async Task<BaseResult<User>> GetUserByEmailAddressAsync(string email)
        {
            return await SearchOneByByAsync(u => u.Email == email);
        }

        /// <summary>
        ///     <para>
        ///         This method returns a user from his entered phone number
        ///     </para>
        ///     <para>
        ///         It takes the user's phone number as parameter 
        ///     </para>
        ///     <para>
        ///         First we search the user with the phone number he entered and the result is contained in the user varriable
        ///     </para>
        ///     <para>
        ///         And at the end we check the user variable if it's not null we return the user 
        ///         and if it's null we return the message "User not found"
        ///     </para>
        /// </summary>
        /// <param name="phoneNumber">Represent the phone number to enter to perform the search for the user</param>
        /// <returns></returns>
        public Task<BaseResult<User>> GetUserByPhoneNumberAsync(string phoneNumber)
        {
           return  SearchOneByByAsync(
                user => user.PhoneNumber == phoneNumber);
        }

        /// <summary>
        ///     <para>
        ///         This method allows you to set a new password
        ///     </para>
        ///     <para>
        ///         First we search the user with the username (phone number or email address) 
        ///         he entered and the result is contained in the user varriable.
        ///     </para>
        ///     <para>
        ///         At the end we check the user variable if it's not null, 
        ///         we check if the new password matches with the confirm password, 
        ///         we modify the values of the properties 
        ///         Password of the User by Hash of the new password and 
        ///         IsConnected by true, 
        ///         we Update the User and 
        ///         we return this user. 
        ///         If the new password doesn't match the confirm password 
        ///         we return the message "Field New Password don't match field confirm password" and
        ///         if the user variable is null we return the message "User not found"
        ///     </para>
        /// </summary>
        /// <param name="request">Represent the model that allows to define a new pasword</param>
        /// <returns></returns>
        public async Task<BaseResult<User>> DefineNewPasswordAsync(UserDefineNewPasswordRequest request)
        {
            
           var result = await SearchOneByByAsync(
                user => user.Email == request.UserName ||
                user.PhoneNumber == request.UserName);
                
            if (result.IsSuccess)
            {
                if (request.NewPassword == request.ConfirmPassword)
                {
                var notInclude = result.Data.FirstName.Split(' ').Concat(result.Data.LastName.Split(' ')).Where(v => request.NewPassword.ToLower().Contains(v.ToLower())) ;
                if (notInclude.Count() > 0)
                {
                    return new BaseResult<User>(BaseResultStatus.BadParams,
                        new Exception("The New password field must not contain a part of the user name")); 
                }else
                {
                    var result1 = await SearchOneByByAsync(
                        user => user.Email == result.Data.Email && user.Password== request.NewPassword.Hash());
                    if (!result1.IsSuccess)
                    {
                       
                            result.Data.Password = request.NewPassword.Hash();
                            result.Data.Isconnected = true;
                            result.Data.CodeConfirm = null;
                            return await UpdateAsync(result.Data);
                        
                    }else
                        return new BaseResult<User>(BaseResultStatus.BadParams,
                            new Exception("The New password field must not match the old password")); 
                }
                }
                else
                    return new BaseResult<User>(BaseResultStatus.BadParams,
                        new Exception("Field New Password don't match field confirm password"));
            }
            return new BaseResult<User>(BaseResultStatus.NotFound,
                new Exception("User not found"));
        }

        /// <summary>
        ///     <para>
        ///         This method allows to check the password recovery code by sms
        ///     </para>
        ///     <para>
        ///         First we search for the user with the entered phone number and the result is contained in the variable user
        ///     </para>
        ///     <para>
        ///         And finally we check the user variable if it's not null, 
        ///         we check if the code stored in the database through the CodeConfirm property of the User class matches with the code we're going to enter 
        ///         and we return this user. 
        ///         If the two codes don't match, 
        ///         we send back the message "Please check your SMS and typing good code" and 
        ///         if the user variable is null 
        ///         we send back the message "User not found"
        ///     </para>
        /// </summary>
        /// <param name="request">Represents the model that allows the verification of the code for the recovery of the password by sms</param>
        /// <returns></returns>
        public async Task<BaseResult<User>> VerifyCodeToPasswordRecoveryBySmsAsync(UserVerifySmsCodeRequest request)
        {
           var result = await GetUserByPhoneNumberAsync(request.UserName);

            if (result.IsNotSuccess)
            {
                result = await GetUserByEmailAddressAsync(request.UserName);
            }

            if (result.IsSuccess)
            {
                if (result.Data.CodeConfirm == request.Code)
                {
                    return result;
                }
                else
                    return new BaseResult<User>(BaseResultStatus.BadParams,
                        new Exception("Please check your SMS and typing good code"));
            }
            return new BaseResult<User>(BaseResultStatus.NotFound,
                new Exception("User not found"));
        }
        #endregion

        #region Methode (Private)

        #endregion
    }
}