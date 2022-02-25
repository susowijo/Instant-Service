using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatnekNetSolution.Core.Models.BaseModel;

namespace InstantService.BO
{
    [Table("CollectionTypes")]
    public class CollectionType : Track
    {
        #region Properties (Public)
        
        /// <summary>
        /// Represent the id of product
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }
        
        /// <summary>
        /// Represent the role name
        /// </summary>
        [Required]
        public float TotalMonth { get; set; }
        
        /// <summary>
        /// Represent the price of product for this type
        /// </summary>
        [Required]
        public float Price { get; set; }
        
        /// <summary>
        /// Represent the product of collection
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Represent all module permission for this role.
        /// </summary>
        public virtual ICollection<Collection> Collections { get; set; }
        
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