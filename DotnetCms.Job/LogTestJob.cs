/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：调度job                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/18 13:45:34                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.Job                                 
*│　类    名： LogTestJob                                      
*└──────────────────────────────────────────────────────────────┘
*/

using NLog;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCms.Job
{
    public class LogTestJob : IJob
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();


        public async Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string serverName = dataMap.GetString("ServerName");
            if (string.IsNullOrEmpty(serverName))
            {
                serverName = "kong";
            }
            logger.Error($"Hello, {serverName},at {DateTime.Now.ToString()}");
            await Task.CompletedTask;
        }
    }
}
