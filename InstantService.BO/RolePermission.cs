using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatnekNetSolution.Core.Models.BaseModel;

namespace InstantService.BO
{
    [Table("RolePermissions")]
    public class RolePermission : Track
    {
        #region Properties (Public)
        
        /// <summary>
        /// Represent the module id
        /// </summary>
        [Required]
        public Guid? ModuleId { get; set; }
        
        /// <summary>
        /// Represent the module
        /// </summary>
        public virtual Module? Module { get; set; }
        
        /// <summary>
        /// Represent the role id
        /// </summary>
        [Required]
        public Guid? RoleId { get; set; }
        
        /// <summary>
        /// Represent the role
        /// </summary>
        public virtual Role? Role { get; set; }
        
        /// <summary>
        /// Specify if user can create data
        /// </summary>
        public bool Create { get; set; }
        
        /// <summary>
        /// Specify if user can read data
        /// </summary>
        public bool Read { get; set; }
        
        /// <summary>
        /// Specify if user can update data
        /// </summary>
        public bool Update { get; set; }
        
        /// <summary>
        /// Specify if user can delete data
        /// </summary>
        public bool Delete { get; set; }
        
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