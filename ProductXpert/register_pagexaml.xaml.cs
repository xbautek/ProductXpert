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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity.Infrastructure;

namespace ProductXpert
{
    /// <summary>
    /// Interaction logic for register_pagexaml.xaml
    /// </summary>
    public partial class register_pagexaml : Page
    {
        public register_pagexaml()
        {
            InitializeComponent();
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
                    Employee r = new(firstname.Text, secondname.Text, username.Text, password.Password);
                    SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSqlLocalDB;Initial Catalog=ProductXpert;Integrated Security=True");
                    
                    SqlCommand cmd = new SqlCommand($"Insert into Pracownicy values ('{r.Name}','{r.SecondName}','{r.Username}','{r.PasswordHash}');", con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                     cmd = new SqlCommand($"select * from Pracownicy where login = @username and haslo = @password;", con);

                    cmd.Parameters.AddWithValue("@username", r.Username);
                    cmd.Parameters.AddWithValue("@password", r.PasswordHash);

                     da = new SqlDataAdapter(cmd);
                     dt = new DataTable();

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("User succesfully added.");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong please try again");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
