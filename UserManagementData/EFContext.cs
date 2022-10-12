using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagementCommon;
using System.ComponentModel.DataAnnotations;

namespace UserManagementData
{
    public class EFContext: DbContext
    {
        public EFContext() : base()
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<UserAuth> UserAuthsTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=UserDatabase;Trusted_Connection=Yes;");
        }


    }

   


}
