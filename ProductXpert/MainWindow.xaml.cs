﻿using System;
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
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media.Animation;
using ProductXpert.Classes;

namespace ProductXpert
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(username.Text))
            {
                MessageBox.Show("Enter your username!");
            }
            else if(string.IsNullOrEmpty(password.Password))
            {
                MessageBox.Show("Enter the password!");
            }
            else
            {
                try
                {
                    Employee first = new Employee(username.Text, password.Password);

                    Database d = new();
                    


                    if(d.CheckUser(username.Text, password.Password))
                    {
                        MessageBox.Show("login successfull");
                        
                        MajorWindow major = new MajorWindow();
                        major.Show();
                        this.Close();
                        

                    }
                    else
                    {
                        MessageBox.Show("username or password is invalide");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OpenNewPage()
        {
            var newWindow = new Window
            {
                Title = "Nowa Strona",
                Content = new register_pagexaml()
            };
            newWindow.ShowDialog();
        }


        private void register_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenNewPage();
        }


        //private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //     System.Windows.Application.Current.Shutdown();
        // }

        
    }
}
