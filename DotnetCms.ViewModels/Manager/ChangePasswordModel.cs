/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：修改密码实体                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/17 19:14:20                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.Manager                                 
*│　类    名： ChangePasswordModel                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.ViewModels.Manager
{
    public class ChangePasswordModel
    {
        /// <summary>
        /// 当前管理员主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword { get; set; }
        /// <summary>
        /// 重复密码
        /// </summary>
        public string NewPasswordRe { get; set; }
    }
}
