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
using UserManagementData;
using System.Security.Cryptography;


namespace UserManagementBusiness
{
    public class UserManagementBL
    {

        UserManagementDL dataObj = new UserManagementDL();

        public List<UserManagementCommon.User> showdata(int predata,int RowsNumb)
        {
           
            return (dataObj.showdata(predata, RowsNumb));
        }

        public  bool addUser(User user)
        {

            Regex telephone = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
            Regex e_mail = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");


            if (user.firstName == "" || user.lastName == "" || user.email == "" || user.telNo == "")
            {
                return false;
            }
            else if (!e_mail.IsMatch(user.email))
            {
                return false;
            }
            else if (!telephone.IsMatch(user.telNo))
            {
                return false;
            }
            else
            {
                dataObj.addDataNew(user.firstName, user.lastName, user.activepassive, user.email, user.address, user.telNo);
                return true;
            }



        }

        public List<UserManagementCommon.User> searchData(string data)
        {
            return dataObj.searchData(data);

        }

        public List<UserManagementCommon.User> comboData(string orderCombo, int predata, int RowsNumb)
        {
            return dataObj.comboData(orderCombo,  predata, RowsNumb);
        }

        //public List<UserManagementCommon.User> callData(int predata, int RowsNumb)
        //{
        //    return dataObj.callData(predata, RowsNumb);

        //}

        public List<UserManagementCommon.User> comboItem(string numbItem)
        {
            return dataObj.comboItem(numbItem);
        }

        public int NumberOf_Rows()
        { 
            return dataObj.NumberOf_Rows();
        }

        public bool Create_UserAuth(string _username, string _password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] password_bytes = Encoding.ASCII.GetBytes(_password);
            byte[] encrypted_bytes = sha1.ComputeHash(password_bytes);
            
            string hashpassword = Convert.ToBase64String(encrypted_bytes);

            return dataObj.Create_UserAuth(_username, hashpassword);
        }


        public bool LoginCheck(string username, string password)
        {
            if(username == null || password == null)
            {
                return false; 
            }
            else {
                return dataObj.Create_UserAuth(username, password);
            }
           
        }

        public void Register_User(string _name,string _password2)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] password_bytes = Encoding.ASCII.GetBytes(_password2);
            byte[] encrypted_bytes = sha1.ComputeHash(password_bytes);

            string hashpassword = Convert.ToBase64String(encrypted_bytes);
            dataObj.Register_User(_name, hashpassword);
        }

        public void Delete(int entityToDelete)
        {
            dataObj.Delete(entityToDelete);
        }
    }

}

