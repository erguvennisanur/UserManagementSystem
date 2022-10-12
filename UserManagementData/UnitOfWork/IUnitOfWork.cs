using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementCommon;
using UserManagementData.IRepositories;

namespace UserManagementData.IConfiguration
{
    public interface IUnitOfWork<out T> where T : EFContext,new()
    {
        T Context { get; }
        IGenericRepository<User> User { get; }
        IGenericRepository<UserAuth> UserAuth { get; }
        void Commit();
    }
}
