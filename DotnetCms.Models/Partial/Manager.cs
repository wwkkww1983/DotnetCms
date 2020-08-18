/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：后台管理员                                                    
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
	/// 后台管理员
	/// </summary>
	public partial class Manager
	{
		/// <summary>
		/// 角色名称
		/// </summary>
		[NotMapped]
		public String RoleName { get; set; }
	}
}
