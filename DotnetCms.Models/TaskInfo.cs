/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：定时任务                                                      
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
	/// 
	/// </summary>
	/// <summary>
	/// yilezhu
	/// 2019-03-13 11:17:00
	/// 定时任务
	/// </summary>
	public partial class TaskInfo
	{
		/// <summary>
		/// 主键
		/// </summary>
		[Key]
		public Int32 Id { get; set; }

		/// <summary>
		///  任务别名
		/// </summary>
		[Required]
		[MaxLength(128)]
		public String Name { get; set; }

		/// <summary>
		///  分组名称
		/// </summary>
		[Required]
		[MaxLength(128)]
		public String Group { get; set; }

		/// <summary>
		///  备注
		/// </summary>
		[MaxLength(256)]
		public String Description { get; set; }

		/// <summary>
		///  程序集
		/// </summary>
		[Required]
		[MaxLength(256)]
		public String Assembly { get; set; }

		/// <summary>
		///  完整类名
		/// </summary>
		[Required]
		[MaxLength(256)]
		public String ClassName { get; set; }

		/// <summary>
		///  状态
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 Status { get; set; }

		/// <summary>
		///  Cron表达式
		/// </summary>
		[Required]
		[MaxLength(128)]
		public String Cron { get; set; }

		/// <summary>
		///  添加时间
		/// </summary>
		[MaxLength(23)]
		public DateTime? AddTime { get; set; }

		/// <summary>
		///  添加人
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 AddManagerId { get; set; }

	}
}
