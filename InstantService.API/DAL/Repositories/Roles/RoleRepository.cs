
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatnekNetSolution.Core.DAL;
using DatnekNetSolution.Core.Extension;
using DatnekNetSolution.Core.Helpers.Result;
using DatnekNetSolution.Core.Models;
using InstantService.API.DAL;
using InstantService.API.Mappings.Contracts.Roles;
using InstantService.API.Services.Utils;
using InstantService.BO;
using Microsoft.EntityFrameworkCore;

namespace InstantService.API.DAL.Repositories.Roles
{
    /// <summary>
    ///     <para>
    ///         This class implements the methods concerning the management 
    ///         of Roles defined in the IRoleRepository class.
    ///     </para>
    /// </summary>
    public class RoleRepository : BaseRepository<InstantServiceContext,Role>, IRoleRepository
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
        public RoleRepository(InstantServiceContext context): base(context)
        {
            _context = context;
        }

        #endregion

        #region Methode (Private)

        #endregion
    }
}
