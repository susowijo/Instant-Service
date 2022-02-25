namespace InstantService.API.Services.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUtilService
    {
        #region Methodes

        /// <summary>
        /// 
        /// </summary>
        /// <param name="separator"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public string JoinList(char separator, params string[] items);

        #endregion
    }
}