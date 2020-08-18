/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：后台管理员角色                                                    
*│　作    者：zhengshengyi                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2020-08-16 23:40:47                            
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetCms.Models
{
	/// <summary>
	/// zhengshengyi
	/// 2020-08-16 23:40:47
	/// 后台管理员角色
	/// </summary>
	public partial class ManagerRole
	{
		/// <summary>
		/// 菜单ID数组  
		/// </summary>
		public virtual int[] MenuIds { get; set; }
	}
}
