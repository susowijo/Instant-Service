using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatnekNetSolution.Core.Models.BaseModel;
using InstantService.BO.Helpers.Enum;

namespace InstantService.BO
{
    [Table("Products")]
    public class Product : Track
    {
        #region Properties (Public)
        
        /// <summary>
        /// Represent the product name
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Represent the product description
        /// </summary>
        [Required]
        public string Description { get; set; }
        
        /// <summary>
        /// Represent the product quantity
        /// </summary>
        [Required]
        public int Quantity { get; set; }
        
        /// <summary>
        /// Represent the min_price of product
        /// </summary>
        [Required]
        public float Price { get; set; }
        
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