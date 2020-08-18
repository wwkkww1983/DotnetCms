/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：后台管理菜单                                                    
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
    public interface IMenuRepository : IBaseRepository<Menu, Int32>
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
        /// 根据主键获取显示状态
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<Boolean> GetDisplayStatusByIdAsync(Int32 id);

        /// <summary>
        /// 修改显示状态
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="status">更改后的状态</param>
        /// <returns></returns>
        Task<Int32> ChangeDisplayStatusByIdAsync(Int32 id, bool status);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="Name">别名</param>
        /// <returns></returns>
        Task<Boolean> IsExistsNameAsync(string Name);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="Name">别名</param>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        Task<Boolean> IsExistsNameAsync(string Name, Int32 Id);

    }
}