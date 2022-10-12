using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UserManagementData.IRepositories;
using UserManagementCommon;
using Microsoft.EntityFrameworkCore;


namespace UserManagementData.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>  where TEntity : class
    {
        private EFContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(EFContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public void Delete(TEntity entityToDelete)
        {
            if(context.Entry(entityToDelete).State == EntityState.Deleted)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public void Delete(object userId)
        {
            TEntity entityToDelete =dbSet.Find(userId);
            Delete(entityToDelete);
        }

        public IEnumerable<TEntity> GetUser(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }


        }

        public TEntity GetUserById(object userId)
        {
            return dbSet.Find(userId);
        }

        public void InsertUser(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void UpdateUser(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

       
    }
}
