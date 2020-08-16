/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：操作日志                                                    
*│　作    者：zhengshengyi                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2020-08-16 23:40:47                             
*└──────────────────────────────────────────────────────────────┘
*/
using DotnetCms.IRepository;
using DotnetCms.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.Services
{
    public class ManagerLogService: IManagerLogService
    {
        private readonly IManagerLogRepository _repository;

        public ManagerLogService(IManagerLogRepository repository)
        {
            _repository = repository;
        }
    }
}