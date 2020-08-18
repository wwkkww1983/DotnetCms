/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：角色权限表                                                    
*│　作    者：zhengshengyi                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2020-08-16 23:40:47                           
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.IServices
{
    public interface IRolePermissionService
    {
        /// <summary>
        /// 通过角色主键获取菜单主键数组
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        int[] GetIdsByRoleId(int RoleId);
    }
}