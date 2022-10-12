using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserManagementCommon;
using UserManagementBusiness;
using System.Windows.Navigation;

namespace UserManagementProject
{
    /// <summary>
    /// Interaction logic for LoginRegister.xaml
    /// </summary>
    public partial class LoginRegister : Window
    {
        UserManagementBL businessObj = new UserManagementBL();
        public LoginRegister()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            string _username;
            string _password;

            _username = username.Text;
            _password = password.Password.ToString();
         
            businessObj.Create_UserAuth(_username, _password);


            MainWindow mainwin= new MainWindow();
            mainwin.Show();
            Close();
            
            
        }

        private void signup_button_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            Close();
        }
    }
}
