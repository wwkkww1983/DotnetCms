/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：登陆实体                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/17 18:47:26                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.Manager                                 
*│　类    名： LoginModel                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.ViewModels.Manager
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CaptchaCode { get; set; }
        public string Ip { get; set; }
        public string ReturnUrl { get; set; }
    }
}
