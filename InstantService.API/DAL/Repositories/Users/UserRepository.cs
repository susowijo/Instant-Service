
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatnekNetSolution.Core.DAL;
using DatnekNetSolution.Core.Extension;
using DatnekNetSolution.Core.Helpers.Result;
using DatnekNetSolution.Core.Models;
using InstantService.API.DAL;
using InstantService.API.Mappings.Contracts.Users;
using InstantService.API.Services.Utils;
using InstantService.BO;
using Microsoft.EntityFrameworkCore;

namespace InstantService.API.DAL.Repositories.Users
{
    /// <summary>
    ///     <para>
    ///         This class implements the methods concerning the management 
    ///         of users defined in the IUserRepository class.
    ///     </para>
    /// </summary>
    public class UserRepository : BaseRepository<InstantServiceContext,User>, IUserRepository
    {
        #region Properties (Private)

        /// <summary>
        ///     <para>
        ///         This property represents the context of the application and will be injected in the controller of this class
        ///     </para>
        /// </summary>
        private readonly InstantServiceContext _context;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(InstantServiceContext context): base(context)
        {
            _context = context;
        }

        #endregion

        #region Methodes (Public)

        /// <summary>
        ///     <para>
        ///         This method creates a user
        ///     </para>
        ///     <para>
        ///         Firstly we check if the Age and the password that the user has entered are valid : 
        ///         the age must be less than or equal to 110 years and greater than or equal to 10 years and 
        ///         the password must contain at least 6 characters and at most 12 characters 
        ///     </para>
        ///     <para>
        ///         In a second step we hash the password that the user has entered and we create the user
        ///     </para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="validateEntity"></param>
        /// <returns></returns>
        public override async  Task<BaseResult<User>>  CreateAsync(User obj, bool validateEntity = false)
        {
            var checkPassword = (obj.Password?.Length > 5);
            int age = (DateTime.Now.Year - obj.Birthday?.Year) ?? 10;
            var checkAge = (age >= 10 && age <= 110);

            if (checkAge)
            {
                if (checkPassword)
                {
                    var checkEmail=await base.SearchOneByByAsync(x=>x.Email== obj.Email);
                    if (!checkEmail.IsSuccess)
                    {
                        var checkPhone=await base.SearchOneByByAsync(x=> x.PhoneNumber== obj.PhoneNumber );
                        if (!checkPhone.IsSuccess)
                        {
                            obj.Password = obj.Password?.Hash();
                            obj.Isconnected = false;
                            obj.EmailConfirm = false;
                            obj.CreateAt = DateTime.Now;
                            obj.StepRegistration = BO.Helpers.Enum.StepEnum.STEPONE;
                            obj.CodeConfirm = UtilService.GenerateUniqueCode();

                            return await base.CreateAsync(obj, validateEntity);
                        }else
                            return  new BaseResult<User>(BaseResultStatus.Failure, new Exception("Phone number already used."));

                    }else
                        return  new BaseResult<User>(BaseResultStatus.Failure, new Exception("Email already used."));

                }
                return  new BaseResult<User>(BaseResultStatus.Failure, new Exception("Invalid password"));
            }
            else
            {
                return new BaseResult<User>(BaseResultStatus.Failure, new Exception("Invalid age. The value must be beetwen 10 and 110"));
            }
        }

        /// <summary>
        ///     <para>
        ///         This method connect a user: Changes the IsConnected property to true
        ///     </para>
        ///     <para>
        ///         It takes as parameter the UserLoginRequest model which has two properties : Email and Password of the user.
        ///     </para>
        ///     <para>
        ///         Firstly we search for a user whose password and email correspond to those passed in parameter
        ///     </para>
        ///     <para>
        ///         Secondly we check if the user exists or not
        ///     </para>
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        public virtual async Task<BaseResult<User>> LoginAsync(UserLoginRequest loginRequest)
        {
            loginRequest.Password = loginRequest.Password?.Hash()!;

            if (loginRequest.Email != null)
            {
                var result = await base.SearchOneByByAsync(f => 
                    f.Password != null && f.Email != null && (f.Email.ToLower().Equals(loginRequest.Email.ToLower()) || f.PhoneNumber == loginRequest.Email)&& 
                    f.Password.Equals(loginRequest.Password));

                if (result.IsSuccess)
                {
                    result.Data.Isconnected = true;
                    return await UpdateAsync(result.Data);
                }
                return new BaseResult<User>(BaseResultStatus.BadParams, new Exception("Bad request"));
            }
            return new BaseResult<User>(BaseResultStatus.BadParams, new Exception("User not found"));
        }
        
        /// <summary>
        ///     <para>
        ///         This method disconnect a user: Changes the IsConnected property to false and update the last section 
        ///     </para>
        ///     <para>
        ///         On first time, we get user based to id
        ///     </para>
        ///     <para>
        ///         Next, if user exist, we update Isconnected properties to false 
        ///     </para>
        ///     <para>
        ///         After updateting Isconnected, we update the last section
        ///     </para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"> When user is not found </exception>
        public virtual async Task<BaseResult<User>> LogoutAsync(Guid? id)
        {
            var result = await  this.GetAsync(id);

            if (result.Status == BaseResultStatus.Success && result.Data != null)
            {
                result.Data.Isconnected = false;
                result.Data.LastconnecteAt = DateTime.Now;
                result = await UpdateAsync(result.Data);
                
                return result;
            }
            return new BaseResult<User>(BaseResultStatus.NotFound, new Exception("User not found"));
        }

        /// <summary>
        ///     <para>
        ///         This method returns all user
        ///     </para>
        ///     <para>
        ///         It takes as parameter the skip, take, orderby and include
        ///     </para>
        /// </summary>
        /// <param name="skip">Represents the value from which we want to return the user</param>
        /// <param name="take">Represents the number of user we want to retrieve</param>
        /// <param name="orderBy">Represents the value that allows to order </param>
        /// <param name="include">Represents the values that must be included </param>
        /// <param name="includeDeletedEntry"></param>
        /// <returns>Users</returns>
        public override Task<BaseResult<ListResult<User>>> GetAllAsync(int? skip = null,
            int? take = null, Func<IQueryable<User>, IQueryable<User>> orderBy = null,
            Func<IQueryable<User>, IQueryable<User>> include = null, bool includeDeletedEntry = false)
        { 
            var result = base.GetAllAsync
                               (
                                   skip,
                                   take,
                                   o => o.OrderBy(c => c.UpdateAt),
                                   null,
                                   includeDeletedEntry
                               );

            return result;
        }


        /// <summary>
        /// This method get all user by name
        /// </summary>
        /// <param name="request">Represents the characters with which we want to find the user</param>
        /// <returns></returns>
        public async Task<BaseResult<ListResult<User>>> GetUserByNameAsync(SearchUserRequest request)
        {
            var dataResult = await SearchAllByAsync
            (
                p => p.FirstName.ToLower().Contains(request.Name.ToLower()) || p.LastName.ToLower().Contains(request.Name.ToLower()),
                o => o.OrderBy(u => u.CreateAt),
                null,
                null,
                null
            );
            
            if (dataResult.IsSuccess)
            {
                var users = new List<User>();
                
                foreach (var u in dataResult.Data.Results)
                {
                    u.FullName = $"{u.FirstName} {u.LastName}";
                    users.Add(u);
                }

                return new BaseResult<ListResult<User>>(dataResult.Status, new ListResult<User>(users, users.Count));
            }

            return new BaseResult<ListResult<User>>(dataResult.Status, new ListResult<User>(new List<User>(), 0), dataResult.Exception);
        }

        #endregion

        #region Methode (Private)

        #endregion
    }
}
