/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：后台管理员角色接口实现                                                    
*│　作    者：zhengshengyi                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2020-08-16 23:40:47                             
*└──────────────────────────────────────────────────────────────┘
*/
using DotnetCms.Core.DbHelper;
using DotnetCms.Core.Options;
using DotnetCms.Core.Repository;
using DotnetCms.IRepository;
using DotnetCms.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCms.Repository.SqlServer
{
    public class ManagerRoleRepository:BaseRepository<ManagerRole,Int32>, IManagerRoleRepository
    {
        public ManagerRoleRepository(IOptionsSnapshot<DbOption> options)
        {
            _dbOption =options.Get("DotnetCmsOption");
            if (_dbOption == null)
            {
                throw new ArgumentNullException(nameof(DbOption));
            }
            _dbConnection = ConnectionFactory.CreateConnection(_dbOption.DbType, _dbOption.ConnectionString);
        }

        public int DeleteLogical(int[] ids)
        {
            string sql = "update [ManagerRole] set IsDelete=1 where Id in @Ids";
            return _dbConnection.Execute(sql, new
            {
                Ids = ids
            });
        }

        public async Task<int> DeleteLogicalAsync(int[] ids)
        {
            string sql = "update [ManagerRole] set IsDelete=1 where Id in @Ids";
            return await _dbConnection.ExecuteAsync(sql, new
            {
                Ids = ids
            });
        }

        public string GetNameById(int id)
        {
            var item = Get(id);
            return item == null ? "角色不存在" : item.RoleName;
        }

        public async Task<string> GetNameByIdAsync(int id)
        {
            var item = await GetAsync(id);
            return item == null ? "角色不存在" : item.RoleName;

        }

        /// <summary>
        /// 事务修改
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        public async Task<int?> InsertByTransAsync(ManagerRole model)
        {
            int? roleId = 0;
            string insertPermissionSql = @"INSERT INTO RolePermission
                (RoleId, MenuId, Permission) VALUES   (@RoleId,@MenuId, '')";
            using (var tran = _dbConnection.BeginTransaction())
            {
                try
                {
                    roleId = await _dbConnection.InsertAsync(model, tran);
                    if (roleId > 0 && model.MenuIds?.Count() > 0)
                    {
                        foreach (var item in model.MenuIds)
                        {
                            await _dbConnection.ExecuteAsync(insertPermissionSql, new
                            {
                                RoleId = model.Id,
                                MenuId = item,
                            }, tran);
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }

            }

            return roleId;
        }

        /// <summary>
        /// 事务新增
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        public async Task<int> UpdateByTransAsync(ManagerRole model)
        {
            int result = 0;
            string insertPermissionSql = @"INSERT INTO RolePermission
                (RoleId, MenuId, Permission)VALUES   (@RoleId,@MenuId, '')";
            string deletePermissionSql = "DELETE FROM RolePermission WHERE RoleId = @RoleId";
            using (var tran = _dbConnection.BeginTransaction())
            {
                try
                {
                    result = await _dbConnection.UpdateAsync(model, tran);
                    if (result > 0 && model.MenuIds?.Count() > 0)
                    {
                        await _dbConnection.ExecuteAsync(deletePermissionSql, new
                        {
                            RoleId = model.Id,

                        }, tran);
                        foreach (var item in model.MenuIds)
                        {
                            await _dbConnection.ExecuteAsync(insertPermissionSql, new
                            {
                                RoleId = model.Id,
                                MenuId = item,
                            }, tran);
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }

            }

            return result;
        }

        /// <summary>
        /// 通过角色ID获取角色分配的菜单列表
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <returns></returns>
        public async Task<List<Menu>> GetMenusByRoleIdAsync(int roleId)
        {
            string sql = @"SELECT   m.Id, m.ParentId, m.Name, m.DisplayName, m.IconUrl, m.LinkUrl, m.Sort, rp.Permission, m.IsDisplay, m.IsSystem, 
                m.AddManagerId, m.AddTime, m.ModifyManagerId, m.ModifyTime, m.IsDelete FROM  RolePermission AS rp INNER JOIN   Menu AS m ON rp.MenuId = m.Id WHERE   (rp.RoleId = @RoleId) AND (m.IsDelete = 0)";
            return (await _dbConnection.QueryAsync<Menu>(sql, new
            {
                RoleId = roleId,
            })).AsList();

        }
    }
}