using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatnekNetSolution.Core.Models.BaseModel;

namespace InstantService.BO
{
    /// <summary>
    /// Media class
    /// </summary>
    [Table("Medias")]
    public class Media: Track
    {
        #region Properties (public)
        
        /// <summary>
        ///
        /// </summary>
        public string SubDir { get; set; }

        /// <summary>
        /// Represent the media name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Represent the Media hashname 
        /// </summary>
        [Required]
        public string Hashname { get; set; }

        /// <summary>
        /// Represent the Media extension 
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Represent the Media size 
        /// </summary>
        public double Size { get; set; }
        
        #endregion

        #region Methodes (Public)

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Media CreateCopy()
        {
            return (Media) Clone();
        }
        #endregion
    }
}
