using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using ProductXpert.Class;

namespace ProductXpert
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
        private void register_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text))
            {
                MessageBox.Show("Enter your username!");
            }
            else if (string.IsNullOrEmpty(password.Password))
            {
                MessageBox.Show("Enter the password!");
            }
            else if (repassword.Password != password.Password)
            {
                MessageBox.Show("Please rewrite the password!");
            }
            else
            {
                try
                {
                    Database.AddUser(firstname.Text, secondname.Text, username.Text, password.Password);
                    MessageBox.Show("User successfully added!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
