using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatnekNetSolution.Core.Models.BaseModel;

namespace InstantService.BO
{
    [Table("Modules")]
    public class Module : Track
    {
        #region Properties (Public)
        
        /// <summary>
        /// Represent the module name
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Represent the description of module
        /// </summary>
        [Required]
        public string Description { get; set; }
        
        /// <summary>
        /// Represent the icon of module
        /// </summary>
        public Guid? IconId { get; set; }
        
        /// <summary>
        /// Represent the icon of module
        /// </summary>
        public virtual Media? Icon { get; set; }
        
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