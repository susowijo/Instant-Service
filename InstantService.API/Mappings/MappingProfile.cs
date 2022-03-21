using System;
using System.Collections.Generic;
using AutoMapper;
using InstantService.API.Mappings.Contracts.CollectionDetails;
using InstantService.API.Mappings.Contracts.Collections;
using InstantService.API.Mappings.Contracts.CollectionTypes;
using InstantService.API.Mappings.Contracts.Modules;
using InstantService.API.Mappings.Contracts.Products;
using InstantService.API.Mappings.Contracts.RolePermissions;
using InstantService.API.Mappings.Contracts.Roles;
using InstantService.API.Mappings.Contracts.UserRoles;
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
            
            // All to CollectionDetail
            CreateMap<Tuple<IList<CollectionDetail>, int>, CollectionDetailListResponse>() .ForMember(dest => dest.CollectionDetails, 
                    opts => 
                        opts.MapFrom(src => src.Item1))
                .ForMember(dest => dest.Count, opts => 
                    opts.MapFrom(src => src.Item2));
            
            // All to Collection
            CreateMap<Tuple<IList<Collection>, int>, CollectionListResponse>() .ForMember(dest => dest.Collections, 
                    opts => 
                        opts.MapFrom(src => src.Item1))
                .ForMember(dest => dest.Count, opts => 
                    opts.MapFrom(src => src.Item2));
            
            // All to CollectionType
            CreateMap<Tuple<IList<CollectionType>, int>, CollectionTypeListResponse>() .ForMember(dest => dest.CollectionTypes, 
                    opts => 
                        opts.MapFrom(src => src.Item1))
                .ForMember(dest => dest.Count, opts => 
                    opts.MapFrom(src => src.Item2));
            
            // All to Module
            CreateMap<Tuple<IList<Module>, int>, ModuleListResponse>() .ForMember(dest => dest.Modules, 
                    opts => 
                        opts.MapFrom(src => src.Item1))
                .ForMember(dest => dest.Count, opts => 
                    opts.MapFrom(src => src.Item2));
            
            // All to Product
            CreateMap<Tuple<IList<Product>, int>, ProductListResponse>() .ForMember(dest => dest.Products, 
                    opts => 
                        opts.MapFrom(src => src.Item1))
                .ForMember(dest => dest.Count, opts => 
                    opts.MapFrom(src => src.Item2));
            
            // All to RolePermission
            CreateMap<Tuple<IList<RolePermission>, int>, RolePermissionListResponse>() .ForMember(dest => dest.RolePermissions, 
                    opts => 
                        opts.MapFrom(src => src.Item1))
                .ForMember(dest => dest.Count, opts => 
                    opts.MapFrom(src => src.Item2));
            
            // All to Role
            CreateMap<Tuple<IList<Role>, int>, RoleListResponse>() .ForMember(dest => dest.Roles, 
                    opts => 
                        opts.MapFrom(src => src.Item1))
                .ForMember(dest => dest.Count, opts => 
                    opts.MapFrom(src => src.Item2));
            
            // All to UserRole
            CreateMap<Tuple<IList<UserRole>, int>, UserRoleListResponse>() .ForMember(dest => dest.UserRoles, 
                    opts => 
                        opts.MapFrom(src => src.Item1))
                .ForMember(dest => dest.Count, opts => 
                    opts.MapFrom(src => src.Item2));
            //next ....
        }

        #endregion
    }
}