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
using DotnetCms.ViewModels.Article;
using DotnetCms.ViewModels.Manager;
using DotnetCms.ViewModels.ManagerRole;
using DotnetCms.ViewModels.Menu;
using DotnetCms.ViewModels.TaskInfo;
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
            CreateMap<ManagerRole, ManagerRoleListModel>();

            #endregion
            #region Manager
            CreateMap<Manager, ManagerListModel>();
            CreateMap<ManagerAddOrModifyModel, Manager>();
            CreateMap<ChangeInfoModel, Manager>();
            #endregion
            #region Menu
            CreateMap<MenuAddOrModifyModel, Menu>();
            CreateMap<Menu, MenuNavView>();
            #endregion

            #region TaskInfo
            CreateMap<TaskInfoAddOrModifyModel, TaskInfo>();
            CreateMap<TaskInfo, TaskInfoDto>();
            #endregion

            #region Article
            CreateMap<Article, ArticleListModel>();
            #endregion

        }
    }
}
