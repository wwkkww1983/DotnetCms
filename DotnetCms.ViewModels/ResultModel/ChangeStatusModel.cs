/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：Manager改变锁定状态实体                                                       
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/17 19:07:47                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.ResultModel                                 
*│　类    名： ChangeStatusModel                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.ViewModels.ResultModel
{
    public class ChangeStatusModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 修改后的状态
        /// </summary>
        public bool Status { get; set; }
    }
}
