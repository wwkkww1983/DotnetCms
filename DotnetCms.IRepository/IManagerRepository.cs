/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：后台管理员                                                    
*│　作    者：zhengshengyi                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2020-08-16 23:40:47                           
*└──────────────────────────────────────────────────────────────┘
*/
using DotnetCms.Core.Repository;
using DotnetCms.Models;
using System;
using System.Threading.Tasks;

namespace DotnetCms.IRepository
{
    public interface IManagerRepository : IBaseRepository<Manager, Int32>
    {
        /// <summary>
        /// 逻辑删除返回影响的行数
        /// </summary>
        /// <param name="ids">需要删除的主键数组</param>
        /// <returns>影响的行数</returns>
        Int32 DeleteLogical(Int32[] ids);
        /// <summary>
        /// 逻辑删除返回影响的行数（异步操作）
        /// </summary>
        /// <param name="ids">需要删除的主键数组</param>
        /// <returns>影响的行数</returns>
        Task<Int32> DeleteLogicalAsync(Int32[] ids);

        /// <summary>
        /// 根据主键获取锁定状态
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Boolean GetLockStatusById(Int32 id);

        /// <summary>
        /// 根据主键获取锁定状态
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<Boolean> GetLockStatusByIdAsync(Int32 id);

        /// <summary>
        /// 修改锁定状态
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="status">更改后的状态</param>
        /// <returns></returns>
        Int32 ChangeLockStatusById(Int32 id, bool status);

        /// <summary>
        /// 修改锁定状态
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="status">更改后的状态</param>
        /// <returns></returns>
        Task<Int32> ChangeLockStatusByIdAsync(Int32 id, bool status);

        /// <summary>
        /// 通过主键获取密码
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        Task<string> GetPasswordByIdAsync(Int32 Id);

        /// <summary>
        /// 通过主键获取密码
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        Task<int> ChangePasswordByIdAsync(Int32 Id, string Password);

        Task<Manager> GetManagerContainRoleNameByIdAsync(int id);


    }
}