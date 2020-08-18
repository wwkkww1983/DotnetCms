/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：角色权限表接口实现                                                    
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
using System.Linq;

namespace DotnetCms.Repository.SqlServer
{
    public class RolePermissionRepository:BaseRepository<RolePermission,Int32>, IRolePermissionRepository
    {
        public RolePermissionRepository(IOptionsSnapshot<DbOption> options)
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
            string sql = "update RolePermission set IsDelete=1 where Id in @Ids";
            return _dbConnection.Execute(sql, new
            {
                Ids = ids
            });
        }

        public async Task<int> DeleteLogicalAsync(int[] ids)
        {
            string sql = "update RolePermission set IsDelete=1 where Id in @Ids";
            return await _dbConnection.ExecuteAsync(sql, new
            {
                Ids = ids
            });
        }

        /// <summary>
        /// 通过角色主键获取菜单主键数组
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public int[] GetIdsByRoleId(int RoleId)
        {
            string sql = "select MenuId from RolePermission where RoleId=@RoleId";
            return _dbConnection.Query<int>(sql, new
            {
                RoleId = RoleId
            }).ToArray();
        }


    }
}