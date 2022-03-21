
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatnekNetSolution.Core.DAL;
using DatnekNetSolution.Core.Extension;
using DatnekNetSolution.Core.Helpers.Result;
using DatnekNetSolution.Core.Models;
using InstantService.API.DAL;
using InstantService.API.Mappings.Contracts.Modules;
using InstantService.API.Services.Utils;
using InstantService.BO;
using Microsoft.EntityFrameworkCore;

namespace InstantService.API.DAL.Repositories.Modules
{
    /// <summary>
    ///     <para>
    ///         This class implements the methods concerning the management 
    ///         of Modules defined in the IModuleRepository class.
    ///     </para>
    /// </summary>
    public class ModuleRepository : BaseRepository<InstantServiceContext,Module>, IModuleRepository
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
        public ModuleRepository(InstantServiceContext context): base(context)
        {
            _context = context;
        }

        #endregion

        #region Methode (Private)

        #endregion
    }
}
