using System;
using System.Threading.Tasks;
using AutoMapper;
using DatnekNetSolution.Core.Helpers.Result;
using DatnekNetSolution.Core.Models;
using InstantService.API.BL.CollectionDetails;
using InstantService.API.Controllers;
using InstantService.API.Mappings.Contracts.CollectionDetails;
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
    public class CollectionDetailsController : InstantServiceBaseController<CollectionDetail, CollectionDetailsController>
    {
        #region Properties (Private)

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<CollectionDetailsController> _logger;

        /// <summary>
        /// Represent the business logic of the CollectionDetail that will be injected in this controller
        /// </summary>
        private readonly ICollectionDetailBl _bl;

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
        /// <param name="bl">Represent the injection of the CollectionDetail's business logic</param>
        /// <param name="mapper">Represents the mapping injection </param>
        public CollectionDetailsController(ILogger<CollectionDetailsController> logger, 
            ICollectionDetailBl bl, 
            IMapper mapper): base(logger, bl, mapper)
        {
            this._logger = logger;
            this._bl = bl;
            this._mapper = mapper;
        }

        #endregion

        #region Action (Public)


        #endregion

        #region Methodes (Public)


        #endregion

        #region Methodes (Public)


        #endregion
    }
}