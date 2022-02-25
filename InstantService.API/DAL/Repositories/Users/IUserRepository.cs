using System;
using System.Threading.Tasks;
using DatnekNetSolution.Core.DAL;
using DatnekNetSolution.Core.Helpers.Result;
using DatnekNetSolution.Core.Models;
using InstantService.API.Mappings.Contracts.Users;
using InstantService.BO;


namespace InstantService.API.DAL.Repositories.Users
{
    /// <summary>
    ///     <para>
    ///         This class defines the methods concerning the management of users 
    ///         and these methods will be implemented in the UserRepository class.
    ///     </para>
    /// </summary>
    public interface IUserRepository: IBaseRepository<User>
    {
        #region Methodes

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
        Task<BaseResult<User>> LoginAsync(UserLoginRequest loginRequest);

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
        Task<BaseResult<User>> LogoutAsync(Guid? id);

        // <summary>
        /// This method get all user by name
        /// </summary>
        /// <param name="request">Represents the characters with which we want to find the user</param>
        /// <returns></returns>
        Task<BaseResult<ListResult<User>>> GetUserByNameAsync(SearchUserRequest request);

        #endregion
    }
}
