/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：DeletegateHelper测试类                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/16 23:33:33                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.Test                                 
*│　类    名： DeletegateHelperTest                                      
*└──────────────────────────────────────────────────────────────┘
*/

using DotnetCms.Core.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotnetCms.Test
{
    public class DeletegateHelperTest
    {
        private readonly IServiceProvider serviceProvider;
        public DeletegateHelperTest()
        {
            serviceProvider = Common.BuildServiceForSqlServer();
        }

        //[Fact]
        public void Test_TryExecute_With_Action()
        {
            var delegateHelper = serviceProvider.GetRequiredService<DelegateHelper>();
            delegateHelper.TryExecute(() => {
                throw new ArgumentNullException("test ArgumentNullException");
            }, nameof(Test_TryExecute_With_FuncT));
            Assert.Equal(0, 0);
        }

        //[Fact]
        public void Test_TryExecute_With_FuncT()
        {
            var delegateHelper = serviceProvider.GetRequiredService<DelegateHelper>();
            var result = delegateHelper.TryExecute<string>(() => {
                throw new ArgumentNullException("test ArgumentNullException");
            }, nameof(Test_TryExecute_With_FuncT));
            Assert.Equal(default(string), result);
        }

        //[Fact]
        public async Task Test_TryExecute_With_FuncT_Async()
        {
            var delegateHelper = serviceProvider.GetRequiredService<DelegateHelper>();
            var result = await delegateHelper.TryExecuteAsync<string>(async () => {
                await Task.Delay(100);
                throw new ArgumentNullException("test ArgumentNullException with async");
            }, nameof(Test_TryExecute_With_FuncT_Async));
            Assert.Equal(default(string), result);
        }
    }
}
