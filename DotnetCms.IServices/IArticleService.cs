/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：文章                                                    
*│　作    者：zhengshengyi                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2020-08-16 23:40:47                           
*└──────────────────────────────────────────────────────────────┘
*/
using DotnetCms.ViewModels.Article;
using DotnetCms.ViewModels.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCms.IServices
{
    public interface IArticleService
    {
        /// <summary>
        /// 根据查询条件获取数据
        /// </summary>
        /// <param name="model">查询实体</param>
        /// <returns>table数据</returns>
        Task<TableDataModel> LoadDataAsync(ArticleRequestModel model);
    }
}