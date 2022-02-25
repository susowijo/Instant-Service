using System.ComponentModel;

namespace InstantService.BO.Helpers.Enum
{
    /// <summary>
    /// Sort of GenderType data to return
    /// </summary>
    public enum CivilityTypeEnum
    {
        /// <summary>
        /// MARRIED
        /// </summary>
        [Description("MARRIED")]
        MARRIED,

        /// <summary>
        /// SINGLE
        /// </summary>
        [Description("SINGLE")]
        SINGLE,

        /// <summary>
        /// DIVORCED
        /// </summary>
        [Description("DIVORCED")]
        DIVORCED,

        /// <summary>
        /// WIDOW_ER
        /// </summary>
        [Description("WIDOW_ER")]
        WIDOW_ER
    }
}
