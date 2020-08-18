/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：TaskInfo更新或者新增实体                                                  
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/18 12:53:45                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.TaskInfo                                 
*│　类    名： TaskInfoAddOrModifyModel                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.ViewModels.TaskInfo
{
    public class TaskInfoAddOrModifyModel
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
		/// Cron表达式
		/// </summary>
        public String Cron { get; set; }
        /// <summary>
		/// 添加时间
		/// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
		/// 修改人
		/// </summary>
        public int AddManagerId { get; set; }
        /// <summary>
        /// 父菜单ID
        /// </summary>
        public Int32 ParentId { get; set; }
        
    }
}
