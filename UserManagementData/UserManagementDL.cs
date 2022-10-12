using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using UserManagementCommon;
using UserManagementData.Repositories;
using UserManagementData.IRepositories;
using UserManagementData.UnitOfWork;

namespace UserManagementData
{
    public class UserManagementDL

    {
        SqlConnection thisConnection = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Database=UserDatabase;Trusted_Connection=Yes;");
        EFContext eFContext = new EFContext();
        UserRepository userRepository = new UserRepository();
        UserAuthRepository userAuthRepository = new UserAuthRepository();
        

        //first screen
        public List<UserManagementCommon.User> showdata(int predata, int RowsNumb)
        {
            //public DataTable showdata(int predata, int RowsNumb)
            // {                  

            //     string Get_Data = "SELECT * FROM Table_User ORDER BY DATE OFFSET " + predata + " ROWS FETCH NEXT " + RowsNumb + " ROWS ONLY";

            //     SqlCommand cmd = thisConnection.CreateCommand();
            //     cmd.CommandText = Get_Data;

            //     SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //     DataTable dt = new DataTable("Users");
            //     sda.Fill(dt);

            return userRepository.Get(predata,RowsNumb);
        }

        //add new user
        public void addDataNew(string name,string surname, bool active_passive, string e_mail, string address,string telephone)
        {
            EFContext eFContext = new EFContext();
            UnitOfWork<EFContext> unitOfWork = new UnitOfWork<EFContext>(eFContext);
            GenericRepository<User> genericRepository;
            IUserRepository userRepository = null;
            userRepository = new UserRepository();

            //using (var ctx = new EFContext())
            using (eFContext)
            {
                var user = new User()
                {
                    firstName = name,
                    lastName = surname,
                    activepassive = active_passive,
                    email = e_mail,
                    address = address,
                    telNo = telephone
                };

                //ctx.User.Add(user);
                //ctx.SaveChanges();

                unitOfWork.User.InsertUser(user);
                unitOfWork.Commit();

            }
            //SqlConnection thisConnection = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Database=UserDatabase;Trusted_Connection=Yes;");

            //string query = " INSERT INTO TABLE_USER (NAME, SURNAME, ACTIVE_PASSIVE, E_MAIL, ADDRESS, TELEPHONE) VALUES (@Name , @Surname, @Active_Passive, @e_mail, @Address, @Telephone)";

            //using (SqlCommand cmd = new SqlCommand(query, thisConnection))
            //{
            //    cmd.Parameters.AddWithValue("@Name", name);
            //    cmd.Parameters.AddWithValue("@Surname", surname);
            //    cmd.Parameters.AddWithValue("@Active_Passive", active_passive);
            //    cmd.Parameters.AddWithValue("@e_mail", e_mail);
            //    cmd.Parameters.AddWithValue("@Address", address);
            //    cmd.Parameters.AddWithValue("@Telephone", telephone);

            //    thisConnection.Open();
            //    cmd.ExecuteNonQuery();
            //}


        }

        //search user 
        public List<UserManagementCommon.User> searchData(string data)
        {
            EFContext eFContext = new EFContext();
            UnitOfWork<EFContext> unitOfWork = new UnitOfWork<EFContext>(eFContext);
            GenericRepository<User> genericRepository;
            IUserRepository userRepository = null;
            userRepository = new UserRepository();


            var user = new User();
            var User = new List<UserManagementCommon.User>();
            User = userRepository.searchData(data);

            //using (var ctx = new E
            //FContext())
            //{
            //    User = ctx.User.Where(b => b.firstName.Contains(data) || b.lastName.Contains(data)).ToList();
            //};
            return userRepository.searchData(data);
        }
        //SqlConnection thisConnection = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Database=UserDatabase;Trusted_Connection=Yes;");
        //thisConnection.Open();
        //string Get_Data = "SELECT * FROM Table_User WHERE Name LIKE '" + data + "' OR Surname LIKE '" + data + "'";

        //SqlCommand cmd = thisConnection.CreateCommand();
        //cmd.CommandText = Get_Data;

        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable("Users");
        //sda.Fill(dt);




        //combo order - user  
        public List<UserManagementCommon.User> comboData(string orderCombo , int predata, int RowsNumb)
        {
            var User = new List<UserManagementCommon.User>();
            var ctx = new EFContext();
            //if (orderCombo.Contains("DESC"))
            //{
            //    using ())
            //    {
            //        User = ctx.User.OrderByDescending(user => user.firstName).Skip(predata).Take(RowsNumb).ToList();
            //    }

            //}
            //else
            //{
            //    using (var ctx = new EFContext())
            //    {
            //        User = ctx.User.OrderBy(user => user.firstName).Skip(predata).Take(RowsNumb).ToList();
            //    }
            //}
            

            if (orderCombo == "Name")
            {
                User = ctx.User.OrderBy(user => user.firstName).Skip(predata).Take(RowsNumb).ToList();
            }
            else if (orderCombo == "Name DESC")
            {
                User = ctx.User.OrderByDescending(user => user.firstName).Skip(predata).Take(RowsNumb).ToList();

            }
            else if (orderCombo == "Surname")
            {
                User = ctx.User.OrderBy(user => user.lastName).Skip(predata).Take(RowsNumb).ToList();

            }
            else if (orderCombo == "Surname DESC")
            {
                User = ctx.User.OrderByDescending(user => user.lastName).Skip(predata).Take(RowsNumb).ToList();

            }
            else if (orderCombo == "Date")
            {
                User = ctx.User.OrderBy(user => user.Date).Skip(predata).Take(RowsNumb).ToList();

            }
            else if (orderCombo == "Date DESC")
            {
                User = ctx.User.OrderByDescending(user => user.Date).Skip(predata).Take(RowsNumb).ToList();

            }
            return (User);
            //orderCombo = orderCombo + " OFFSET " + predata + " ROWS FETCH NEXT " + RowsNumb + " ROWS ONLY ";
            //string Get_Data =  orderCombo;           

            //SqlCommand cmd = thisConnection.CreateCommand();
            //cmd.CommandText = Get_Data;

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable("User");
            //sda.Fill(dt);


        }
        
        //public Data_Table callData(int predata, int RowsNumb)
        //{     
        //    //    //string Get_Data = "SELECT * FROM Table_User ORDER BY Name OFFSET " + predata + " ROWS FETCH NEXT " + RowsNumb + " ROWS ONLY";
        //    //    //SqlCommand cmd = thisConnection.CreateCommand();
        //    //    //cmd.CommandText = Get_Data;

        //    //    //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    //    //DataTable dt = new DataTable("Users");
        //    //    //sda.Fill(dt);
        //    return (dt);
        //}


        //combo - number
        public List<UserManagementCommon.User> comboItem(string numb_Combo)
        {
           
            var user= new User();
            var User = new List<UserManagementCommon.User>();

            //using (var ctx = new EFContext())
            //{
               
            //    User = ctx.User.OrderBy(user => user.firstName).Skip(0).Take(Int32.Parse("numb_Combo")).ToList();
            //};

            //string Get_Data = "";
            //Get_Data=numb_Combo;

            //SqlCommand cmd = thisConnection.CreateCommand();
            //cmd.CommandText = Get_Data;

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable("User");
            //sda.Fill(dt);

            return userRepository.comboItem(numb_Combo);
        }

        //row number 
        public int NumberOf_Rows()

        {           
                   
            //string Get_Data = "SELECT COUNT (*) FROM Table_User ";
            //thisConnection.Open();

            //SqlCommand cmd = thisConnection.CreateCommand();
            //cmd.CommandText = Get_Data;

            //int RowsNumb = Convert.ToInt16(cmd.ExecuteScalar());
            //thisConnection.Close();
            return userRepository.NumberOf_Rows();

        }

        
        //create user auth 
        public bool Create_UserAuth(string username, string password)
        {               
            return userAuthRepository.Create_UserAuth(username,password);
        }
        
        //register new user
        public void Register_User(string _name, string _password2)
        {
            var userAuth= new UserAuth()
            {
                UserName = _name,
                Password = _password2,
                Active = true,
                Admin = false,

            };
             userAuthRepository.InsertUser(userAuth);
            
        }

        public void Delete(int entityToDelete)
        {
            UnitOfWork<EFContext> unitOfWork = new UnitOfWork<EFContext>(eFContext);
            unitOfWork.User.Delete(entityToDelete);
            unitOfWork.Commit();
        }
    }

       

}
