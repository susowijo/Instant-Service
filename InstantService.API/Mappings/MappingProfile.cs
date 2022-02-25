using System;
using System.Collections.Generic;
using AutoMapper;
using InstantService.API.Mappings.Contracts.Users;
using InstantService.BO;

namespace InstantService.API.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingProfile: Profile
    {
        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public MappingProfile()
        {
            // All to user
            CreateMap<Tuple<IList<User>, int>, UserListResponse>() .ForMember(dest => dest.Users, 
                    opts => 
                        opts.MapFrom(src => src.Item1))
                .ForMember(dest => dest.Count, opts => 
                    opts.MapFrom(src => src.Item2));
            //next ....
        }

        #endregion
    }
}