using System.Collections.Generic;
using InstantService.BO;

namespace InstantService.API.Mappings.Contracts.Modules
{
    /// <summary>
    /// This class represents the model used to retrieve all Modules
    /// </summary>
    public class ModuleListResponse: BaseResponse
    {
        /// <summary>
        /// Represent a list of Module
        /// </summary>
        public virtual ICollection<Module> Modules { get; set; }

        /// <summary>
        /// Represents the number of existing Module
        /// </summary>
        public int Count { get; set; }
    }
}