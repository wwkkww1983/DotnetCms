/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：TaskInfo页面显示的实体                                                   
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/18 12:57:02                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.TaskInfo                                 
*│　类    名： TaskInfoDto                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.ViewModels.TaskInfo
{
    public class TaskInfoDto
    {
        /// <summary>
		/// 主键
		/// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 任务别名
        /// </summary>
        public String Name { get; set; }
        /// <summary>
		/// 分组名称
		/// </summary>
        public String Group { get; set; }
        /// <summary>
		/// 备注
		/// </summary>
        String Description { get; set; }
        /// <summary>
		/// 程序集
		/// </summary>
        public String Assembly { get; set; }
        /// <summary>
		/// 完成类名
		/// </summary>
        public String ClassName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public Int32 Status { get; set; }

        /// <summary>
        /// Cron表达式
        /// </summary>
        public String Cron { get; set; }

    }
}
