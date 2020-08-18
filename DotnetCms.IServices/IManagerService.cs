/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：后台管理员                                                    
*│　作    者：zhengshengyi                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2020-08-16 23:40:47                           
*└──────────────────────────────────────────────────────────────┘
*/
using DotnetCms.Models;
using DotnetCms.ViewModels.Manager;
using DotnetCms.ViewModels.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCms.IServices
{
    public interface IManagerService
    {
        /// <summary>
        /// 根据查询条件获取数据
        /// </summary>
        /// <param name="model">查询实体</param>
        /// <returns>table数据</returns>
        Task<TableDataModel> LoadDataAsync(ManagerRequestModel model);

        /// <summary>
        /// 新增或者修改服务
        /// </summary>
        /// <param name="item">新增或者修改试图实体</param>
        /// <returns>结果实体</returns>
        Task<BaseResult> AddOrModifyAsync(ManagerAddOrModifyModel model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="Ids">主键id数组</param>
        /// <returns>结果实体</returns>
        Task<BaseResult> DeleteIdsAsync(int[] Ids);

        /// <summary>
        /// 修改锁定状态
        /// </summary>
        /// <param name="model">修改锁定状态实体</param>
        /// <returns>结果</returns>
        Task<BaseResult> ChangeLockStatusAsync(ChangeStatusModel model);

        /// <summary>
        /// 登录操作，成功则写日志
        /// </summary>
        /// <param name="model">登录实体</param>
        /// <returns>实体对象</returns>
        Task<Manager> SignInAsync(LoginModel model);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">修改密码实体</param>
        /// <returns>结果</returns>
        Task<BaseResult> ChangePasswordAsync(ChangePasswordModel model);

        /// <summary>
        /// 根据ID获取Manager对象
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>结果</returns>
        Task<Manager> GetManagerByIdAsync(int id);

        /// <summary>
        /// 根据ID获取Manager对象包含角色名称
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>结果</returns>
        Task<Manager> GetManagerContainRoleNameByIdAsync(int id);

        /// <summary>
        /// 个人资料修改
        /// </summary>
        /// <param name="model">个人资料修改实体</param>
        /// <returns>结果</returns>
        Task<BaseResult> UpdateManagerInfoAsync(ChangeInfoModel model);
    }
}