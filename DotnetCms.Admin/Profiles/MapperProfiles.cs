/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：AutoMapper映射关系配置                                                   
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/16 21:51:19                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.Admin.Profiles                                 
*│　类    名： MapperProfiles                                      
*└──────────────────────────────────────────────────────────────┘
*/

using AutoMapper;
using DotnetCms.Models;
using DotnetCms.ViewModels.ManagerRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCms.Admin.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            #region ManagerRole
            CreateMap<ManagerRoleAddOrModifyModel, ManagerRole>();
            #endregion
           
        }
    }
}
