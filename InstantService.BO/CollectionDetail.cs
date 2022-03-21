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
        /// Represent the payment identification code
        /// </summary>
        [Required]
        public string PaymentCode { get; set; }
        
        /// <summary>
        /// Represent the id of payment picture
        /// </summary>
        //[Required]
        public Guid? PaymentPictureId { get; set; }
        
        /// <summary>
        /// Represent the payment picture
        /// </summary>
        public virtual Media? PaymentPicture { get; set; }
        
        /// <summary>
        /// Represent the collection
        /// </summary>
        public virtual Collection? Collection { get; set; }
        
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