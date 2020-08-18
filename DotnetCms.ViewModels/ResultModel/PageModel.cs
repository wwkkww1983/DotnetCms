/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：分页相关实体                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/17 19:03:38                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.ResultModel                                 
*│　类    名： PageModel                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.ViewModels.ResultModel
{
    public class PageModel
    {
        public int Page { get; set; }
        public int Limit { get; set; }

        public string Key { get; set; }

        public PageModel()
        {
            Page = 1;
            Limit = 10;
        }
    }
}
