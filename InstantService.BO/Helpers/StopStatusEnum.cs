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
    public enum StopStatusEnum
    {
        /// <summary>
        /// SENDED
        /// </summary>
        [Description("SENDED")]
        SENDED,

        /// <summary>
        /// CONFIRMED
        /// </summary>
        [Description("CONFIRMED")]
        CONFIRMED,

        /// <summary>
        /// REJECTED
        /// </summary>
        [Description("REJECTED")]
        REJECTED,
    }
}
