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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using UserManagementCommon;
using UserManagementBusiness;
using UserManagementData;
using System.ComponentModel.DataAnnotations;

namespace UserManagementProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        UserManagementBL businessObj = new UserManagementBL();
        int predata=0;
        int postdata=5;
        int RowsNumb =5;
        bool OrderMenuClick = false;
        public MainWindow()
        {

            InitializeComponent();

            peopleList.ItemsSource = businessObj.showdata(predata,RowsNumb);
            peopleList.SelectedIndex = 0;
        }
         
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                firstName = firstName.Text,
                lastName = lastName.Text,
                activepassive = activepassive.IsChecked.HasValue ? activepassive.IsChecked.Value : false,
                email = email.Text,
                address = address.Text,
                telNo = telNo.Text,
            };

            bool register = businessObj.addUser(user);
            if (register)
            {
                alert.Text = "added user";
            }
            else
            {
                alert.Text = "Error";
            }

            try
            {
                User userdata = new User();

                bool newBool = activepassive.IsChecked.HasValue ? activepassive.IsChecked.Value : false;

                firstName.Text = String.Empty;
                lastName.Text = String.Empty;
                activepassive.IsChecked = newBool;
                email.Text = String.Empty;
                address.Text = String.Empty;
                telNo.Text = String.Empty;


            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }

        private void findButton_Click_1(object sender, RoutedEventArgs e)
        {

            var data = findBox.Text;

            peopleList.ItemsSource = businessObj.searchData(data);
            peopleList.SelectedIndex = 0;

            changeFindText.Text = "search";
            findBox.Text = "";

        }

        private void findBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            changeFindText.Text = "";
        }


        //order function
        string textCombo="";

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
            SqlConnection thisConnection = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Database=UserDatabase;Trusted_Connection=Yes;");
            thisConnection.Open();
            
             StringBuilder sBuilder = new StringBuilder("");
           

            if (((System.Windows.Controls.ContentControl)comboBox.SelectedValue).Content.ToString() == "First Name [A-Z]")
            {
                sBuilder.Append("Name");
               
            }
            else if (((System.Windows.Controls.ContentControl)comboBox.SelectedValue).Content.ToString() == "First Name [Z-A]")
            {
                 sBuilder.Append("Name DESC");
            }
            else if (((System.Windows.Controls.ContentControl)comboBox.SelectedValue).Content.ToString() == "Last Name [A-Z]")
            {
                 sBuilder.Append("Surname");
            }
            else if (((System.Windows.Controls.ContentControl)comboBox.SelectedValue).Content.ToString() == "Last Name [Z-A]")
            {
                 sBuilder.Append("Surname DESC");
            }
            else if (((System.Windows.Controls.ContentControl)comboBox.SelectedValue).Content.ToString() == "Register Date [Newest]")
            {
                sBuilder.Append("Date DESC");
            }
            else if (((System.Windows.Controls.ContentControl)comboBox.SelectedValue).Content.ToString() == "Register Date [Oldest]")
            {
            
                 sBuilder.Append("Date");
            }

            textCombo = sBuilder.ToString();
            peopleList.ItemsSource = businessObj.comboData(textCombo, predata,RowsNumb);


            OrderMenuClick = true; 
        }

        

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

            if (OrderMenuClick)
            {
                if (postdata < businessObj.NumberOf_Rows())
                {
                    btnNext.IsEnabled = true;
                }
                if (predata > 0)
                {
                    btnPrevious.IsEnabled = true;
                    predata -= RowsNumb;
                    postdata -= RowsNumb;
                }
                else
                {
                    predata = 0;
                    btnPrevious.IsEnabled = false;
                }
                peopleList.ItemsSource = businessObj.comboData(textCombo,predata,RowsNumb);
            }
            else
            {
                if(postdata < businessObj.NumberOf_Rows())
                {
                    btnNext.IsEnabled = true;
                }
                if (predata > 0 )
                {
                    btnPrevious.IsEnabled = true;
                   
                    predata -= RowsNumb;
                    postdata -= RowsNumb;
                }
                else
                {
                    predata = 0;
                    btnPrevious.IsEnabled = false;
                }
                peopleList.ItemsSource = businessObj.showdata(predata, RowsNumb);
            }
           

           
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            if (OrderMenuClick) {
                if (predata > 0)
                {
                    btnPrevious.IsEnabled = true;
                }

                if (postdata < businessObj.NumberOf_Rows())
                {
                    
                    btnNext.IsEnabled = true;
                    predata +=RowsNumb;
                    postdata += RowsNumb;
                }
                else
                {
                    
                        
                    btnNext.IsEnabled = false;
                }
                peopleList.ItemsSource = businessObj.comboData(textCombo, predata, RowsNumb);
            }
            else
            {
                if (predata > 0)
                {
                    btnPrevious.IsEnabled = true;
                }

                if (postdata < businessObj.NumberOf_Rows())
                {
                    btnNext.IsEnabled = true;
                    predata += RowsNumb;
                    postdata += RowsNumb;
                }
                else
                {
                   
                    btnNext.IsEnabled = false;
                }
                peopleList.ItemsSource = businessObj.showdata(predata, RowsNumb);
            }
           

           

        }

        //number of records to display
        private void ComboBox_Item(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection thisConnection = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Database=UserDatabase;Trusted_Connection=Yes;");
            thisConnection.Open();
            
            
            if (ComboBoxRow.SelectedIndex == 0)
            {
                RowsNumb = 5;
                if (OrderMenuClick)
                {
                    DataTable dt = new DataTable();
                    //dt = businessObj.comboData(textCombo, predata, RowsNumb);
                     peopleList.ItemsSource = dt.DefaultView;
                }
                else
                {
                    peopleList.ItemsSource = businessObj.showdata(predata, RowsNumb);
                }
               
                postdata = predata + RowsNumb;
               
            }
            else if (ComboBoxRow.SelectedIndex == 1)
            {
                RowsNumb = 10;
                if (OrderMenuClick)
                {
                    DataTable dt = new DataTable();
                    //dt = businessObj.comboData(textCombo, predata, RowsNumb);
                     peopleList.ItemsSource = dt.DefaultView;
                }
                else
                {
                    peopleList.ItemsSource = businessObj.showdata(predata, RowsNumb);
                }              
                postdata = predata + RowsNumb;
              
            }
            else if (ComboBoxRow.SelectedIndex == 2)
            {
                RowsNumb = 15;
                if (OrderMenuClick)
                {
                    DataTable dt = new DataTable();
                    //dt = businessObj.comboData( textCombo, predata, RowsNumb);
                     peopleList.ItemsSource = dt.DefaultView;
                }
                else
                {
                    peopleList.ItemsSource = businessObj.showdata(predata, RowsNumb);
                }
              
                postdata = predata + RowsNumb;
              
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            LoginRegister logwin = new LoginRegister();
            logwin.Show();
            Close();

        }

        int user_update;
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            businessObj.Delete(user_update);
        }

        private void peopleList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dynamic selected_row = peopleList.SelectedItem;
            firstName.Text=selected_row.firstName.ToString();
            lastName.Text=selected_row.lastName.ToString();
            activepassive.IsChecked=selected_row.activepassive;
            email.Text=selected_row.email.ToString();
            address.Text=selected_row.address.ToString();
            telNo.Text=selected_row.telNo.ToString();

            user_update = selected_row.Id;
        }
    }



} 