using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantService.BO.Helpers.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public enum MediaTypeEnum
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Presentation")]
        Presentation,

        /// <summary>
        /// 
        /// </summary>
        [Description("Profile")]
        Profile,

        /// <summary>
        /// 
        /// </summary>
        [Description("ProfileBackground")]
        ProfileBackground,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("PresentationLink")]
        PresentationLink,
        /// <summary>
        /// 
        /// </summary>
        [Description("ProfileLink")]
        ProfileLink,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("ProfileBackgroudLink")]
        ProfileBackgroundLink,
        /// <summary>
        /// 
        /// </summary>
        [Description("MediaImage")]
        MediaImage,
    }
}
