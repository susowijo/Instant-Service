using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatnekNetSolution.Core.Models.BaseModel;

namespace InstantService.BO
{
    [Table("UserRoles")]
    public class UserRole : Track
    {
        #region Properties (Public)
        
        /// <summary>
        /// Represent the user id
        /// </summary>
        [Required]
        public Guid? UserId { get; set; }
        
        /// <summary>
        /// Represent the user
        /// </summary>
        public virtual User? User { get; set; }
        
        /// <summary>
        /// Represent the role id
        /// </summary>
        [Required]
        public Guid? RoleId { get; set; }
        
        /// <summary>
        /// Represent the role
        /// </summary>
        public virtual Role? Role { get; set; }
        
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