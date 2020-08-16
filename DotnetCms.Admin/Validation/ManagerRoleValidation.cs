﻿/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：ManagerRole更新或者新增校验规则类                                                   
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/16 17:28:49                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.Admin.Validation                                 
*│　类    名： ManagerRoleValidation                                      
*└──────────────────────────────────────────────────────────────┘
*/

using DotnetCms.ViewModels.ManagerRole;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCms.Admin.Validation
{
    public class ManagerRoleValidation : AbstractValidator<ManagerRoleAddOrModifyModel>
    {
        public ManagerRoleValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.RoleName).NotEmpty().Length(1, 64).WithMessage("角色名称不能为空并且长度不能超过64个字符");
            RuleFor(x => x.RoleType).NotNull().InclusiveBetween(1, 2).WithMessage("角色类型格式不正确");
            RuleFor(x => x.IsSystem).NotNull().WithMessage("是否系统默认必须选择");
            RuleFor(x => x.Remark).Length(0, 128).WithMessage("备注信息的长度必须符合规则");
        }
    }
}
