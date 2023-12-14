using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryImplementation
{
    public interface IRepository
    {
        Task<bool> SqlQuerySpBoolAsync(string storedProcedure, object parameters);
        Task<List<TEntity>> SqlQuerySpListAsync<TEntity>(string storedProcedure, object parameters) where TEntity : class;
        Task<TEntity> SqlQuerySpFirstAsync<TEntity>(string storedProcedure, object parameters) where TEntity : class;
    }
}
