/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：布尔类型的结果                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/18 10:49:07                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.ResultModel                                 
*│　类    名： BooleanResult                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.ViewModels.ResultModel
{
    public class BooleanResult : BaseResult
    {
        public Boolean Data { get; set; }
    }
}
