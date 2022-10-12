using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UserManagementCommon;
using Microsoft.EntityFrameworkCore;
using UserManagementData.IRepositories;
using UserManagementData.UnitOfWork;

namespace UserManagementData.Repositories
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private EFContext context;
       // internal DbSet<UserAuth> dbSet;
        public void Delete(UserAuth entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(object userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAuth> GetUser(Expression<Func<UserAuth, bool>> filter = null, Func<IQueryable<UserAuth>, IOrderedQueryable<UserAuth>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public UserAuth GetUserById(object userId)
        {
            throw new NotImplementedException();
        }

        public void InsertUser(UserAuth entity)
        {
            //EFContext efContext = new EFContext();
            //dbSet = efContext.Set<UserAuth>();
            //dbSet.Add(entity);
            context.UserAuthsTable.Add(entity);
            UnitOfWork<EFContext> unitOfWork = new UnitOfWork<EFContext>(context);
            unitOfWork.Commit();
        }

        public void UpdateUser(UserAuth entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Create_UserAuth(string username, string password)
        {
            using (var ctx = new EFContext())
            {
                var userAuth = new UserAuth();
                userAuth = ctx.UserAuthsTable.Where(b => b.UserName == username).FirstOrDefault();
                var hashedpassword = userAuth.Password;
                return userAuth.Password == hashedpassword;
            }
        }
        
       
    }
}
