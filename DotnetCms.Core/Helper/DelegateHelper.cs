/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：委托帮助类                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/16 22:32:50                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.Core.Helper                                 
*│　类    名： DelegateHelper                                      
*└──────────────────────────────────────────────────────────────┘
*/

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCms.Core.Helper
{
    public class DelegateHelper
    {
        private readonly ILogger<DelegateHelper> Logger;
        public DelegateHelper(ILogger<DelegateHelper> logger = null)
        {
            Logger = logger;
        }

        public void TryExecute(Action action, string funcName = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"{funcName}() Blow Up.");
            }
        }

        public T TryExecute<T>(Func<T> func, string funcName = null)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"{funcName}() Blow Up.");
                return default(T);
            }
        }

        public async Task<T> TryExecuteAsync<T>(Func<Task<T>> func, string funcName = null)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"{funcName}() Blow Up.");
                return default(T);
            }
        }

    }
}
