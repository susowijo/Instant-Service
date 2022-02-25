using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatnekNetSolution.Core.Models.BaseModel;
using InstantService.BO.Helpers.Enum;

namespace InstantService.BO
{
    [Table("Collections")]
    public class Collection : Track
    {
        #region Properties (Public)
        
        /// <summary>
        /// Represent the last date of collection
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }
        
        /// <summary>
        /// Represent the last date of collection
        /// </summary>
        public StopStatusEnum? Stop { get; set; }

        /// <summary>
        /// Represent the collection mode whit product we will have an end.
        /// </summary>
        public virtual CollectionType CollectionType { get; set; }

        /// <summary>
        /// Represent all module permission for this role.
        /// </summary>
        public virtual ICollection<CollectionDetail> CollectionDetails { get; set; }
        
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