﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using ProductXpert.Class;

namespace ProductXpert.ViewModel
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : UserControl
    {
        // Clients list
        public List<Customer> MyClients { get; set; }



        public Clients()
        {

            InitializeComponent();

            //Generating data to DataGrid from database
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                MyClients = _context.Customers
                    .Select(m => new Customer
                    {
                        CustomerId = m.CustomerId,
                        CompanyName = m.CompanyName,
                        ContactName = m.ContactName,
                        Phone = m.Phone,
                        Email = m.Email
                    })
                    .ToList();
            }

            CustomersList.AutoGenerateColumns = false;
            CustomersList.ItemsSource = MyClients;
        }


        //Function adds new client to the database
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(companynametxt.Text) || string.IsNullOrEmpty(contactnametxt.Text) || string.IsNullOrEmpty(emailtxt.Text) || string.IsNullOrEmpty(phonetxt.Text))
                {
                    MessageBox.Show("Uzupełnij wszystkie komórki panelu dodawania rekordu do bazy!");
                }
                else if (!(emailtxt.Text.Contains('@')))
                {
                    MessageBox.Show("Zły email!");
                }
                else
                {
                    Customer newCustomer = new Customer
                    {
                        CompanyName = companynametxt.Text,
                        ContactName = contactnametxt.Text,
                        Phone = phonetxt.Text,
                        Email = emailtxt.Text
                    };

                    using (ProductXpertContext _context = new ProductXpertContext())
                    {
                        _context.Customers.Add(newCustomer);
                        _context.SaveChanges();
                    }
                    Refresh();

                    companynametxt.Text = "";
                    contactnametxt.Text = "";
                    phonetxt.Text = "";
                    emailtxt.Text = "";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędny format!");
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd!");
            }
            
        }

        // Function refreshing clients list
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                MyClients = _context.Customers
                    .Select(m => new Customer
                    {
                        CustomerId = m.CustomerId,
                        CompanyName = m.CompanyName,
                        ContactName = m.ContactName,
                        Phone = m.Phone,
                        Email = m.Email
                    })
                    .ToList();
            }

            CustomersList.AutoGenerateColumns = false;
            CustomersList.ItemsSource = MyClients;
        }

        // Function refreshing clients list
        private void Refresh()
        {
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                MyClients = _context.Customers
                    .Select(m => new Customer
                    {
                        CustomerId = m.CustomerId,
                        CompanyName = m.CompanyName,
                        ContactName = m.ContactName,
                        Phone = m.Phone,
                        Email = m.Email
                    })
                    .ToList();
            }

            CustomersList.AutoGenerateColumns = false;
            CustomersList.ItemsSource = MyClients;
        }

        // Event which unselects selected row
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.Key == Key.Escape)
                {
                    DataGrid grid = (DataGrid)sender;
                    grid.UnselectAll();
                }
            
        }

        //Function deletes row
        private void Delete_click(object sender, RoutedEventArgs e)
        {
            if (CustomersList.SelectedItem is Customer selectedMaterial)
            {
                MessageBoxResult result = MessageBox.Show("Czy jesteś pewien, że chcesz usunąć ten rekord?", "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (ProductXpertContext _context = new ProductXpertContext())
                    {
                        var materialToRemove = _context.Customers.FirstOrDefault(m => m.CustomerId == selectedMaterial.CustomerId);
                        if (materialToRemove != null)
                        {
                            _context.Customers.Remove(materialToRemove);
                            _context.SaveChanges();
                        }
                    }
                }
            }
            Refresh();
        }

        //Function which selects rows 
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selecttxt.Text))
                {
                    MessageBox.Show("Uzupełnij nazwę, po której chcesz wyszukać produkt!");
                }
                else
                {
                    using (ProductXpertContext _context = new ProductXpertContext())
                    {
                        MyClients = _context.Customers
                            .Where(m => m.CompanyName == selecttxt.Text)
                            .Select(m => new Customer
                            {
                                CustomerId = m.CustomerId,
                                CompanyName = m.CompanyName,
                                ContactName = m.ContactName,
                                Phone = m.Phone,
                                Email = m.Email
                            })
                            .ToList();
                    }

                    CustomersList.AutoGenerateColumns = false;
                    CustomersList.ItemsSource = MyClients;
                    selecttxt.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd!");
            }
        }

        // Function which determines that only numbers might be inputed to textboxt
        private void phonetxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
