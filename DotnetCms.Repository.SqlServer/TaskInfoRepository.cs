/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：定时任务接口实现                                                    
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
    public class TaskInfoRepository : BaseRepository<TaskInfo, Int32>, ITaskInfoRepository
    {
        public TaskInfoRepository(IOptionsSnapshot<DbOption> options)
        {
            _dbOption = options.Get("DotnetCmsOption");
            if (_dbOption == null)
            {
                throw new ArgumentNullException(nameof(DbOption));
            }
            _dbConnection = ConnectionFactory.CreateConnection(_dbOption.DbType, _dbOption.ConnectionString);
        }

        public int DeleteLogical(int[] ids)
        {
            string sql = "update TaskInfo set IsDelete=1 where Id in @Ids";
            return _dbConnection.Execute(sql, new
            {
                Ids = ids
            });
        }

        public async Task<int> DeleteLogicalAsync(int[] ids)
        {
            string sql = "update TaskInfo set IsDelete=1 where Id in @Ids";
            return await _dbConnection.ExecuteAsync(sql, new
            {
                Ids = ids
            });
        }

        public async Task<bool> ResumeSystemStoppedAsync()
        {
            string sql = "update TaskInfo set Status=0 where Status=3";
            return await _dbConnection.ExecuteAsync(sql) > 0;
        }

        public async Task<bool> SystemStoppedAsync()
        {
            string sql = "update TaskInfo set Status=3 where Status=0";
            return await _dbConnection.ExecuteAsync(sql) > 0;
        }

        public async Task<bool> UpdateStatusByIdsAsync(int[] ids, int Status)
        {
            string sql = "update TaskInfo set Status=@Status where Id in @Ids";
            return await _dbConnection.ExecuteAsync(sql, new
            {
                Status = Status,
                Ids = ids,
            }) > 0;
        }

        public async Task<List<TaskInfo>> GetListByJobStatuAsync(int Status)
        {
            string sql = "select * from TaskInfo where Status=@Status ";
            var result = await _dbConnection.QueryAsync<TaskInfo>(sql, new
            {
                Status = Status,
            });
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                return new List<TaskInfo>();
            }
        }


        public async Task<bool> IsExistsNameAsync(string Name)
        {
            string sql = "select Id from TaskInfo where Name=@Name";
            var result = await _dbConnection.QueryAsync<int>(sql, new
            {
                Name = Name,
            });
            if (result != null && result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> IsExistsNameAsync(string Name, Int32 Id)
        {
            string sql = "select Id from TaskInfo where Name=@Name and Id <> @Id ";
            var result = await _dbConnection.QueryAsync<int>(sql, new
            {
                Name = Name,
                Id = Id,
            });
            if (result != null && result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}