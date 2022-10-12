using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManagementCommon;


namespace UserManagementData.IRepositories
{
     public interface IUserAuthRepository : IGenericRepository<UserAuth> 
    {
        public bool Create_UserAuth(string username, string password);

    }
}
