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
using InstantService.API.BL.Roles;
using InstantService.API.DAL;
using InstantService.API.DAL.Repositories.Roles;
using InstantService.API.Mappings.Contracts.Roles;
using InstantService.API.Services.Utils;
using InstantService.BO;
using Microsoft.EntityFrameworkCore;

namespace InstantService.API.BL.Roles
{
    public class RoleBl: RoleRepository, IRoleBl
    {
        #region Properties (Private)

        /// <summary>
        /// Represent the context of the application that will be injected into this controller
        /// </summary>
        private readonly InstantServiceContext _context;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Represents the constructor of this class
        /// </summary>
        /// <param name="context">Represent the context injection</param>
        public RoleBl(InstantServiceContext context) :
            base(context)
        {
            _context = context;
        }

        #endregion

        #region Methode (Public)


        #endregion

        #region Methode (Private)

        #endregion
    }
}