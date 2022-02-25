using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using DatnekNetSolution.Core.DAL;
using DatnekNetSolution.Core.Helpers.Result;
using DatnekNetSolution.Core.Models;
using DatnekNetSolution.Core.Models.BaseModel;
using DatnekNetSolution.Core.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Environments = InstantService.API.Services.Utils.Environments;

namespace InstantService.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TController"></typeparam>
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public abstract class InstantServiceBaseController<TEntity, TController> : ControllerBase 
        where TEntity: Track
        where TController: ControllerBase
    {
         #region Properties (Private)
             public bool IsDevEnv
             {
                 get => Environments.Current == EnvironmentEnum.Dev 
                        || Environments.Current == EnvironmentEnum.Test;
             }

            private readonly ILogger<TController> _logger;
            private readonly IBaseRepository<TEntity> _bl;
            private readonly IMapper _mapper;

         #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public InstantServiceBaseController(ILogger<TController> logger, IBaseRepository<TEntity> repository, IMapper mapper)
        {
            this._logger = logger;
            this._bl = repository;
            this._mapper = mapper;
        }
        #endregion

        #region Action (Public)

        // GET: api/controller
        /// <summary>
        ///     This action method returns all items 
        /// </summary>
        /// <param name="skip">
        ///     Represent the number from which the recuperation should start
        /// </param>
        /// <param name="take">
        ///     Represent the number of elements to retrieve.
        /// </param>
        /// <returns></returns>
        [HttpGet("{skip}/{take}")]
        public virtual  Task<BaseHttpResponse<ListResult<TEntity>>> GetAllAsync(int skip, int take)
            => ExecuteBlAsync(() => _bl.GetAllAsync(skip, take));
        

        // GET: api/controller/5
        /// <summary>
        ///     This action method returns the item whose id is specified in parameter
        /// </summary>
        /// <param name="id">Represent the identifier of the element to return</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual Task<BaseHttpResponse<TEntity>> GetLByIdAsync(Guid id)
            => ExecuteBlAsync(() => _bl.GetAsync(id));

        // POST: api/controller
        /// <summary>
        ///     This action method returns the created item
        ///     if everything went well and the statusCode = 200 
        ///     otherwise we return the error message and the status code = 400
        /// </summary>
        /// <param name="model">Represent the creation model of an item.</param>
        /// <returns></returns>
        [HttpPost]
        public virtual  Task<BaseHttpResponse<TEntity>> PostAsync([FromBody] TEntity model)
            => ExecuteBlAsync(() => _bl.CreateAsync(model));


        // PUT: api/controller/5
        /// <summary>
        ///     This action method returns the updated item
        ///     if everything went well and the statusCode = 200 
        ///     otherwise we return the error message and the status code = 400
        /// </summary>
        /// <param name="id">Represent the identifier of the item to update</param>
        /// <param name="model">Represent the model to update</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual  Task<BaseHttpResponse<TEntity>> PutAsync(Guid? id, [FromBody] TEntity model)
            => ExecuteBlAsync(() => _bl.UpdateAsync(model));

        // DELETE: api/controller/5
        /// <summary>
        ///     This action method returns the deleted element
        ///     #Description: Element is not actually deleted, rather it is achived
        /// </summary>
        /// <param name="id">Represent the identifier of the item to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual Task<BaseHttpResponse<TEntity>> DeletePartialAsync(Guid? id)
            => ExecuteBlAsync(() => _bl.DeletePartialAsync(id));

        // DELETE: api/controller/5
        /// <summary>
        ///     This action method returns the deleted element
        /// </summary>
        /// <param name="id">Represent the identifier of the item to delete</param>
        /// <returns></returns>
        [HttpDelete("Permanent/{id}")]
        public virtual Task<BaseHttpResponse<TEntity>> DeleteAsync(Guid? id)
            => ExecuteBlAsync(() => _bl.DeleteAsync(id));
        

        #endregion
        
        
        #region Methods (Protected)

        /// <summary>
        /// Execute some business logic asynchronously and returns a consistent HttpResponseDto wich own the data to be returned along with some status.
        /// </summary>
        /// <typeparam name="TReturn">The type of the data returned by the Business Logic.</typeparam>
        /// <param name="blFunctionToExecute">The business logic function to execute.</param>
        /// <returns>A consistent HttpResponseDto filled with the returned data if any and the status.</returns>
        protected async Task<BaseHttpResponse<TReturn>> ExecuteBlAsync<TReturn>(Func<Task<BaseResult<TReturn>>> blFunctionToExecute)
        {
            try
            {
                // First executes the business logic function
                var result = await blFunctionToExecute();

                // If the result of the business logic is unexpected
                if (result.IsUnexpected)
                {
                    Debug.WriteLine($"[ControllerBase]: {result.Reason ?? result.Exception?.Message}");
                    _logger.LogError(result.Exception, $"[ControllerBase]{result.Reason ?? result.Exception?.Message}");
                }
                    

                // Creates a response using the business logic function result
                var response = CreateHttpResponseBlFromResult(result);
                return response;
            }
            catch (Exception exception)
            {
                // If an unexpected error occurs then returns an unexpected response (should not occur as BL are included in a try/catch)
                Debug.WriteLine($"[ControllerBase]: Unexpected error when executing Business logic from controller. { exception.Message}");
                _logger.LogCritical("[ControllerBase]Unexpected error when executing Business logic from controller.", exception);
               
                return new BaseHttpResponse<TReturn>
                {
                    ResultStatus = BaseResultStatus.Unexpected,
                    Reason = exception.Message
                };
            }
        }

        /// <summary>
        /// Execute some business logic asynchronously and returns a consistent HttpResponseDto wich own the data to be returned along with some status.
        /// </summary>
        /// <param name="blFunctionToExecute">The business logic function to execute.</param>
        /// <returns>A consistent HttpResponseDto filled with the returned data if any and the status.</returns>
        protected async Task<BaseHttpResponse> ExecuteBlAsync(Func<Task<BaseResult>> blFunctionToExecute)
        {
            try
            {
                // First executes the business logic function
                var result = await blFunctionToExecute();

                // If the result of the business logic is unexpected
                if (result.IsUnexpected)
                    Debug.WriteLine($"[ControllerBase]: {result.Reason ?? result.Exception?.Message}");

                // Creates a response using the business logic function result
                var response = CreateHttpResponseBlFromResult(result);
                return response;
            }
            catch (Exception exception)
            {
                // If an unexpected error occurs then returns an unexpected response (should not occur as BL are included in a try/catch)
                Debug.WriteLine($"[ControllerBase]: Unexpected error when executing Business logic from controller. { exception.Message}");
                _logger.LogCritical("[ControllerBase]Unexpected error when executing Business logic from controller.", exception);

                return new BaseHttpResponse
                {
                    ResultStatus = BaseResultStatus.Unexpected,
                    Reason = exception.Message
                };
            }
        }

        /// <summary>
        /// Execute some business logic and returns a consistent HttpResponseDto wich own the data to be returned along with some status.
        /// </summary>
        /// <param name="blFunctionToExecute">The business logic function to execute.</param>
        /// <returns></returns>
        protected BaseHttpResponse ExecuteBl(Func<BaseResult> blFunctionToExecute)
            => ExecuteBlAsync(() => Task.Run(blFunctionToExecute)).Result;

        /// <summary>
        /// Execute some business logic and returns a consistent HttpResponseDto wich own the data to be returned along with some status.
        /// </summary>
        /// <typeparam name="TReturn">The type of the data returned by the Business Logic.</typeparam>
        /// <param name="blFunctionToExecute">The business logic function to execute.</param>
        /// <returns></returns>
        protected BaseHttpResponse<TReturn> ExecuteBl<TReturn>(Func<BaseResult<TReturn>> blFunctionToExecute)
            => ExecuteBlAsync(() =>  Task.Run(blFunctionToExecute)).Result;

        /// <summary>
        /// Creates a new HttpResponseDto given a Result{TResult}.
        /// </summary>
        /// <param name="result">The result to convert in HttpResponseDto.</param>
        /// <returns>The newly created HttpResponseDto.</returns>
        protected BaseHttpResponse CreateHttpResponseBlFromResult(BaseResult result)
            => new BaseHttpResponse
            {
                ResultStatus = result.Status,
                Reason = CreateReason(result.Exception) ?? result.Reason
            };

        /// <summary>
        /// Creates a new HttpResponseDto given a Result{TResult}.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="result">The result to convert in HttpResponseDto.</param>
        /// <returns>The newly created HttpResponseDto.</returns>
        protected BaseHttpResponse<TResult> CreateHttpResponseBlFromResult<TResult>(BaseResult<TResult> result)
            => new BaseHttpResponse<TResult>
            {
                Data = result.Data,
                ResultStatus = result.Status,
                Reason = CreateReason(result.Exception) ?? result.Reason
            };

        /// <summary>
        /// Creates a reason from an exception.
        /// Depending on the environment gives some details.
        /// </summary>
        /// <param name="exception">The exception used to create the reason text.</param>
        /// <returns>The exception casted as text if environment allows it.</returns>
        protected string CreateReason(Exception exception)
        {
            // If no exception then no reason
            if (exception == null)
                return null;

            // No detail in Acceptance or Production
            if (!IsDevEnv)
                return null;

            // Returns the full detail of the exception in order to ease the debug
            return exception.Message;
        }

        #endregion Methods (Protected)
    }
}