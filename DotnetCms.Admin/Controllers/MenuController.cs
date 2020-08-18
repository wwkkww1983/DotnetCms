﻿using DotnetCms.Admin.Validation;
using DotnetCms.Core.Helper;
using DotnetCms.IServices;
using DotnetCms.ViewModels.Menu;
using DotnetCms.ViewModels.ResultModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCms.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, ActionName("LoadData")]
        public async Task<string> LoadDataAsync([FromQuery] MenuRequestModel model)
        {
            return JsonHelper.ObjectToJSON(await _service.LoadDataAsync(model));
        }

        [HttpGet, ActionName("AddOrModify")]
        public async Task<IActionResult> AddOrModifyAsync()
        {
            return View(await _service.GetChildListByParentIdAsync(0));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> AddOrModify([FromForm] MenuAddOrModifyModel item)
        {
            var result = new BaseResult();
            MenuValidation validationRules = new MenuValidation();
            ValidationResult results = validationRules.Validate(item);
            if (results.IsValid)
            {
                result = await _service.AddOrModifyAsync(item);
            }
            else
            {
                result.ResultCode = ResultCodeAddMsgKeys.CommonModelStateInvalidCode;
                result.ResultMsg = results.ToString("||");
            }
            return JsonHelper.ObjectToJSON(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> Delete(int[] menuId)
        {
            return JsonHelper.ObjectToJSON(await _service.DeleteIdsAsync(menuId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> ChangeDisplayStatus([FromForm] ChangeStatusModel item)
        {
            var result = new BaseResult();
            ManagerLockStatusModelValidation validationRules = new ManagerLockStatusModelValidation();
            ValidationResult results = validationRules.Validate(item);
            if (results.IsValid)
            {
                result = await _service.ChangeDisplayStatusAsync(item);
            }
            else
            {
                result.ResultCode = ResultCodeAddMsgKeys.CommonModelStateInvalidCode;
                result.ResultMsg = results.ToString("||");
            }
            return JsonHelper.ObjectToJSON(result);
        }

        [HttpGet]
        public async Task<string> IsExistsName([FromQuery] MenuAddOrModifyModel item)
        {
            var result = await _service.IsExistsNameAsync(item);
            return JsonHelper.ObjectToJSON(result);
        }

        [HttpGet, ActionName("LoadDataWithParentId")]
        public async Task<string> LoadDataWithParentIdAsync([FromQuery] int ParentId = -1)
        {
            return JsonHelper.ObjectToJSON(await _service.GetChildListByParentIdAsync(ParentId));
        }
    }
}
