using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManagementCommon;

namespace UserManagementData.IRepositories
{
    public interface IUserRepository: IGenericRepository<User>
    {
        List<UserManagementCommon.User> searchData(string data);

        List<UserManagementCommon.User> comboItem(string numb_Combo);

        public int NumberOf_Rows();

        public List<User> Get(int predata, int RowsNumb);
    }
}
