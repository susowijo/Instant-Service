using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatnekNetSolution.Core.Models.BaseModel;
using InstantService.BO.Helpers.Enum;

namespace InstantService.BO
{
    [Table("CollectionDetails")]
    public class CollectionDetail : Track
    {
        #region Properties (Public)
        
        /// <summary>
        /// Represent the amount that was paid
        /// </summary>
        [Required]
        public float Amount { get; set; }
        
        /// <summary>
        /// Represent the id of collection
        /// </summary>
        [Required]
        public Guid CollectionId { get; set; }
        
        /// <summary>
        /// Represent the id of collection
        /// </summary>
        [Required]
        public string PaymentId { get; set; }
        
        /// <summary>
        /// Represent the id of collection
        /// </summary>
        [Required]
        public Media PaymentPicture { get; set; }
        
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