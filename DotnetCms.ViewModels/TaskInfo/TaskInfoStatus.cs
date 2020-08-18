/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：状态枚举数                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/18 12:59:51                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.TaskInfo                                 
*│　类    名： TaskInfoStatus                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DotnetCms.ViewModels.TaskInfo
{
    public enum TaskInfoStatus : byte
    {
        [Description("执行中")]
        Running,
        [Description("已完成")]
        Completed,
        [Description("已停止")]
        Stopped,
        [Description("系统停止")]
        SystemStopped,
    }
}
