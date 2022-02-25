using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatnekNetSolution.Core.Models.BaseModel;

namespace InstantService.BO
{
    [Table("Roles")]
    public class Role : Track
    {
        #region Properties (Public)
        
        /// <summary>
        /// Represent the role name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Represent all module permission for this role.
        /// </summary>
        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        /// <summary>
        /// Represent all user who have this role.
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
        
        #endregion
        
        #region Methodes (Public)

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public User CreateCopy()
        {
            return (User)Clone();
        }

        #endregion
    }
}