﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductXpert.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductXpert.ViewModel
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl
    {
        //Products list
        public List<Product> MyProducts { get; set; }
        public Products()
        {
            InitializeComponent();


            //Generating data to DataGrid from database
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                var products = _context.Products.Select(p => p.ProductName).Distinct().ToList();
                selectbox.ItemsSource = products;

                MyProducts = _context.Products
                    .Join(_context.Materials, p => p.MaterialId, m => m.MaterialId, (p, m) => new Product
                    {
                        ProductId = p.ProductId,
                        MaterialName = m.MaterialName,
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice,
                        Amount = p.Amount,
                        MinimalAmount = p.MinimalAmount
                    })
                    .Select(p => new Product
                    {
                        ProductId = p.ProductId,
                        MaterialName = p.MaterialName,
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice,
                        Amount = p.Amount,
                        MinimalAmount = p.MinimalAmount
                    })
                    .ToList();
            }

            ProductsList.AutoGenerateColumns = false;
            ProductsList.ItemsSource = MyProducts;
        }

        //Function adds new client to the database
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(nametxt.Text) || string.IsNullOrEmpty(materialnametxt.Text) || string.IsNullOrEmpty(pricetxt.Text) || string.IsNullOrEmpty(amounttxt.Text) || string.IsNullOrEmpty(minimalamounttxt.Text))
                {
                    MessageBox.Show("Wprowadź wszystkie dane!");
                }
                else
                {
                    // Pobierz dane z formularza
                    string productName = nametxt.Text;
                    string materialName = materialnametxt.Text;
                    string priceText = pricetxt.Text;
                    priceText = priceText.Replace('.', ',');
                    decimal unitPrice = decimal.Parse(priceText);
                    int amount = int.Parse(amounttxt.Text);
                    int minimalAmount = int.Parse(minimalamounttxt.Text);

                    using (ProductXpertContext _context = new ProductXpertContext())
                    {
                        // Pobierz materiał na podstawie jego nazwy
                        Material? material = _context.Materials.FirstOrDefault(m => m.MaterialName == materialName);
                        if (material != null)
                        {
                            // Utwórz nowy obiekt produktu
                            Product newProduct = new Product
                            {
                                ProductName = productName,
                                UnitPrice = unitPrice,
                                Amount = amount,
                                MinimalAmount = minimalAmount,
                                MaterialId = material.MaterialId // Przypisz ID materiału do właściwości MaterialId produktu
                            };

                            // Dodaj produkt do kontekstu i zapisz zmiany w bazie danych
                            _context.Products.Add(newProduct);
                            _context.SaveChanges();

                            // Odśwież listę produktów
                            Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono materiału o podanej nazwie.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędny format!");
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd!");
            }
            
        }

        //Function which selects rows 
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (ProductXpertContext _context = new ProductXpertContext())
                {
                    string selectedProduct = selectbox.SelectedItem as string;


                    MyProducts = _context.Products
                        .Join(_context.Materials, p => p.MaterialId, m => m.MaterialId, (p, m) => new Product
                        {
                            ProductId = p.ProductId,
                            MaterialName = m.MaterialName,
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice,
                            Amount = p.Amount,
                            MinimalAmount = p.MinimalAmount
                        })
                        .Where(p => p.ProductName == selectedProduct) // Klauzula where dla wyszukiwania po nazwie produktu
                        .Select(p => new Product
                        {
                            ProductId = p.ProductId,
                            MaterialName = p.MaterialName,
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice,
                            Amount = p.Amount,
                            MinimalAmount = p.MinimalAmount
                        })
                        .ToList();
                }

                ProductsList.AutoGenerateColumns = false;
                ProductsList.ItemsSource = MyProducts;
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd!");
            }
            
        }

        // Function refreshing clients list
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                var products = _context.Products.Select(p => p.ProductName).Distinct().ToList();
                selectbox.ItemsSource = products;

                MyProducts = _context.Products
                    .Join(_context.Materials, p => p.MaterialId, m => m.MaterialId, (p, m) => new Product
                    {
                        ProductId = p.ProductId,
                        MaterialName = m.MaterialName,
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice,
                        Amount = p.Amount,
                        MinimalAmount = p.MinimalAmount
                    })
                    .Select(p => new Product
                    {
                        ProductId = p.ProductId,
                        MaterialName = p.MaterialName,
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice,
                        Amount = p.Amount,
                        MinimalAmount = p.MinimalAmount
                    })
                    .ToList();
            }

            ProductsList.AutoGenerateColumns = false;
            ProductsList.ItemsSource = MyProducts;
        }

        // Function refreshing clients list
        private void Refresh()
        {
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                var products = _context.Products.Select(p => p.ProductName).Distinct().ToList();
                selectbox.ItemsSource = products;

                MyProducts = _context.Products
                    .Join(_context.Materials, p => p.MaterialId, m => m.MaterialId, (p, m) => new Product
                    {
                        ProductId = p.ProductId,
                        MaterialName = m.MaterialName,
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice,
                        Amount = p.Amount,
                        MinimalAmount = p.MinimalAmount
                    })
                    .Select(p => new Product
                    {
                        ProductId = p.ProductId,
                        MaterialName = p.MaterialName,
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice,
                        Amount = p.Amount,
                        MinimalAmount = p.MinimalAmount
                    })
                    .ToList();
            }

            ProductsList.AutoGenerateColumns = false;
            ProductsList.ItemsSource = MyProducts;
        }

        //Function deletes row
        private void Delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductsList.SelectedItem is Product selectedProduct)
                {
                    MessageBoxResult result = MessageBox.Show("Czy jesteś pewien, że chcesz usunąć ten rekord?", "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        using (ProductXpertContext _context = new ProductXpertContext())
                        {
                            var productToRemove = _context.Products.FirstOrDefault(m => m.ProductId == selectedProduct.ProductId);
                            if (productToRemove != null)
                            {
                                _context.Products.Remove(productToRemove);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
                Refresh();
            }
            catch (SqlException)
            {
                MessageBox.Show("Nie możesz usunąć produktu, który jest przypisany do zamówienia!");
            }
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
    }
}
