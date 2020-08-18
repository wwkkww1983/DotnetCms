/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：文章                                                    
*│　作    者：zhengshengyi                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2020-08-16 23:40:47                             
*└──────────────────────────────────────────────────────────────┘
*/
using AutoMapper;
using DotnetCms.Core.Extensions;
using DotnetCms.IRepository;
using DotnetCms.IServices;
using DotnetCms.ViewModels.Article;
using DotnetCms.ViewModels.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCms.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TableDataModel> LoadDataAsync(ArticleRequestModel model)
        {
            string conditions = "where IsDeleted=0 ";//未删除的
            if (!model.Key.IsNullOrWhiteSpace())
            {
                conditions += "and Title like '%@Key%' ";
            }
            var list = (await _repository.GetListPagedAsync(model.Page, model.Limit, conditions, "Id desc", model)).ToList();
            return new TableDataModel
            {
                count = await _repository.RecordCountAsync(conditions, model),
                data = _mapper.Map<List<ArticleListModel>>(list),
            };
        }
    }
}