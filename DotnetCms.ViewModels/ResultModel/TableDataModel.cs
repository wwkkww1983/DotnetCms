/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：表返回的数据                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/17 19:00:10                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.ResultModel                                 
*│　类    名： TableDataModel                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.ViewModels.ResultModel
{

    public class TableDataModel
    {

        /// <summary>
        /// 状态码
        /// </summary>
        public int code { get; set; } = 0;
        /// <summary>
        /// 操作消息
        /// </summary>
        public string msg { get; set; } = "操作成功";

        /// <summary>
        /// 总记录条数
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 数据内容
        /// </summary>
        public dynamic data { get; set; }

    }
}
