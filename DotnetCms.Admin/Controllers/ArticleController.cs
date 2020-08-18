﻿using DotnetCms.Core.Helper;
using DotnetCms.IServices;
using DotnetCms.ViewModels.Article;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCms.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        public async Task<string> LoadData([FromQuery] ArticleRequestModel model)
        {
            return JsonHelper.ObjectToJSON(await _service.LoadDataAsync(model));
        }

        [HttpGet]
        public ActionResult AddOrModify()
        {
            return View();
        }
    }
}
