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

namespace UserManagementData.Repositories
{
    public class UserRepository :  IUserRepository 
    {
        private EFContext context;
        internal DbSet<User> dbSet;
        public UserRepository()
        {
            
        }

       
        public IEnumerable<User> GetUser(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = "")
        {

            throw new NotImplementedException();
        }

        public List<User> Get(int predata, int RowsNumb)
        {
            var User = new List<UserManagementCommon.User>();
            using (var ctx = new EFContext())
            {
                User = ctx.User.Skip(predata).Take(RowsNumb).ToList();
            }
            return User;
        }

        public User GetUserById(object userId)
        {           
            User? user = dbSet.Find(keyValues: userId);
            return user;
        }

        public void InsertUser(User entity)
        {
            dbSet.Add(entity);
            
        }

        public void Delete(User entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Delete(object userId)
        {
            throw new NotImplementedException();
        }


        public List<UserManagementCommon.User> searchData(string data)
        {

            using (var ctx = new EFContext())
            {
                var User = new List<UserManagementCommon.User>();
                User = ctx.User.Where(b => b.firstName.Contains(data) || b.lastName.Contains(data)).ToList();
                return User;
            };
            
        }

        public List<UserManagementCommon.User> comboItem(string numb_Combo) { 
          
           using (var ctx = new EFContext())
            {
                var User = new List<UserManagementCommon.User>();
                User = ctx.User.OrderBy(user => user.firstName).Skip(0).Take(Int32.Parse("numb_Combo")).ToList();
                return User;
            };
        }

        public int NumberOf_Rows() 
         {
            using (var ctx = new EFContext())
            {
               return ctx.User.Count();
            }
                
                    
        }
       
    }
}