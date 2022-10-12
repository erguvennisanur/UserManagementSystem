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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        UserManagementBL businessObj = new UserManagementBL();
        public Register()
        {
            InitializeComponent();
        }

        private void register_button_Click(object sender, RoutedEventArgs e)
        {
            string _name;
            string _password2;
            _name = name.Text;
            _password2 = password2.Password.ToString();


            businessObj.Register_User(_name, _password2);

            LoginRegister logwin = new LoginRegister();
            logwin.Show();
            Close();
        }
    }
}
