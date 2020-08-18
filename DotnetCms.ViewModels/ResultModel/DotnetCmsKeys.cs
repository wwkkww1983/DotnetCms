/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：加密关键字                                                     
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/17 19:25:45                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.ResultModel                                 
*│　类    名： DotnetCmsKeys                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.ViewModels.ResultModel
{
    public class DotnetCmsKeys
    {
        /// <summary>
        /// Aes加密关键字
        /// </summary>
        public static readonly string AesEncryptKeys = "zhengshengyi";
        public static readonly string DefaultPassword = "dotnetcms999";
    }
}
