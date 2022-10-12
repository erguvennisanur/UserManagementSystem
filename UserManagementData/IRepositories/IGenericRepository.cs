using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManagementCommon;

namespace UserManagementData.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetUser(Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity GetUserById(object userId);
        void InsertUser(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Delete(object userId);
        void UpdateUser(TEntity entityToUpdate);


        
    }
}
