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
using ProductXpert.Class;
using ProductXpert.ViewModel;
using ProductXpert;
using Microsoft.Data.SqlClient;

namespace ProductXpert.ViewModel
{
    /// <summary>
    /// Interaction logic for Materials.xaml
    /// </summary>
    public partial class Materials : UserControl
    {
        //Materials list
        public List<Material> MyMaterials { get; set; }

        public Materials()
        {
            InitializeComponent();

            //Generating data to DataGrid from database
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                MyMaterials = _context.Materials
                    .Select(m => new Material
                    {
                        MaterialId = m.MaterialId,
                        MaterialName = m.MaterialName,
                        Description = m.Description,
                        Price = m.Price,
                        Weight = m.Weight
                    })
                    .ToList();
            }

            MaterialsList.AutoGenerateColumns = false;
            MaterialsList.ItemsSource = MyMaterials;
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

        // Function refreshing clients list
        private void Refresh()
        {
             using (ProductXpertContext _context = new ProductXpertContext())
            {
                MyMaterials = _context.Materials
                    .Select(m => new Material
                    {
                        MaterialId = m.MaterialId,
                        MaterialName = m.MaterialName,
                        Description = m.Description,
                        Price = m.Price,
                        Weight = m.Weight
                    })
                    .ToList();
            }

            MaterialsList.AutoGenerateColumns = false;
            MaterialsList.ItemsSource = MyMaterials;
        }

        //Function deletes row
        private void Delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MaterialsList.SelectedItem is Material selectedMaterial)
                {
                    MessageBoxResult result = MessageBox.Show("Czy jesteś pewien, że chcesz usunąć ten rekord?", "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        using (ProductXpertContext _context = new ProductXpertContext())
                        {
                            var materialToRemove = _context.Materials.FirstOrDefault(m => m.MaterialId == selectedMaterial.MaterialId);
                            if (materialToRemove != null)
                            {
                                _context.Materials.Remove(materialToRemove);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
                Refresh();
            }
            catch (SqlException)
            {
                MessageBox.Show("Nie możesz usunąć materiału który jest przypisany do produktu!");
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd!");
            }
            
        }

        //Function adds new client to the database
        private void Add_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(nametxt.Text) || string.IsNullOrEmpty(desctxt.Text) || string.IsNullOrEmpty(pricetxt.Text) || string.IsNullOrEmpty(weighttxt.Text))
                {
                    MessageBox.Show("Uzupełnij wszystkie komórki panelu dodawania rekordu do bazy!");
                }
                else if(Convert.ToDecimal(pricetxt.Text.Replace('.', ',')) < 0 || Convert.ToDecimal(weighttxt.Text.Replace('.', ',')) < 0){
                    MessageBox.Show("Cena i waga muszą być wartościami nieujemnymi!");
                }
                else
                {
                    Material newMaterial = new Material
                    {
                        MaterialName = nametxt.Text,
                        Description = desctxt.Text,
                        Price = Convert.ToDecimal(pricetxt.Text.Replace('.', ',')),
                        Weight = Convert.ToDecimal(weighttxt.Text.Replace('.', ','))
                    };

                    using (ProductXpertContext _context = new ProductXpertContext())
                    {
                        _context.Materials.Add(newMaterial);
                        _context.SaveChanges();
                    }
                    Refresh();

                    nametxt.Text = "";
                    desctxt.Text = "";
                    pricetxt.Text = "";
                    weighttxt.Text = "";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Błędny format!");
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd - sprawdź wpisane dane");
            }
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
                        MyMaterials = _context.Materials
                            .Where(m => m.MaterialName == selecttxt.Text)
                            .Select(m => new Material
                            {
                                MaterialId = m.MaterialId,
                                MaterialName = m.MaterialName,
                                Description = m.Description,
                                Price = m.Price,
                                Weight = m.Weight
                            })
                            .ToList();
                    }

                    MaterialsList.AutoGenerateColumns = false;
                    MaterialsList.ItemsSource = MyMaterials;
                    selecttxt.Text = "";
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Błąd!");
            }
           
        }

        // Function refreshing clients list
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
