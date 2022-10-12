using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementCommon;
using UserManagementData.IConfiguration;
using UserManagementData.IRepositories;
using UserManagementData.Repositories;



namespace UserManagementData.UnitOfWork
{
    public class UnitOfWork <T>: IUnitOfWork<T>, IDisposable where T : EFContext,new()
    {
        private EFContext context;
        private IGenericRepository<User> user;
        private IGenericRepository<UserAuth> userAuth;

        public T Context => throw new NotImplementedException();

        public UnitOfWork(EFContext context)
        {
            this.context = context;
        }

        public IGenericRepository<User> User
        {
            get
            {
                return user ?? (user = new GenericRepository<User>(context));
            }
        }

        public IGenericRepository<UserAuth> UserAuth
        {
            get
            {
                return userAuth ?? (userAuth = new GenericRepository<UserAuth>(context));
            }
        }

        

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
