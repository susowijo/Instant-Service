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
        [Required]
        public string Extension { get; set; }

        /// <summary>
        /// Represent the Media size 
        /// </summary>
        [Required]
        public double Size { get; set; }

        /// <summary>
        /// Represent the id of titular of IdPaper
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Represent the titular of IdPaper
        /// </summary>
        public virtual User User { get; set; }
        public Guid CollectionDetaiId { get; set; }
        
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
