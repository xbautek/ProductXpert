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

namespace ProductXpert.ViewModel
{
    /// <summary>
    /// Interaction logic for Materials.xaml
    /// </summary>
    public partial class Materials : UserControl
    {
        public List<Materialy> MyMaterials { get; set; }

        public Materials()
        {
            InitializeComponent();

            using (ProductXpertContext _context = new ProductXpertContext())
            {
                MyMaterials = _context.Materialy
                    .Select(m => new Materialy
                    {
                        IdMaterialu = m.IdMaterialu,
                        Nazwa = m.Nazwa,
                        Opis = m.Opis,
                        Cena = m.Cena,
                        Waga = m.Waga
                    })
                    .ToList();
            }

            MaterialsList.AutoGenerateColumns = false;
            MaterialsList.ItemsSource = MyMaterials;
        }

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                // Usunięcie zaznaczenia z aktualnie zaznaczonego elementu
                DataGrid grid = (DataGrid)sender;
                grid.UnselectAll();
            }
        }

        private void Refresh()
        {
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                MyMaterials = _context.Materialy
                    .Select(m => new Materialy
                    {
                        IdMaterialu = m.IdMaterialu,
                        Nazwa = m.Nazwa,
                        Opis = m.Opis,
                        Cena = m.Cena,
                        Waga = m.Waga
                    })
                    .ToList();
            }

            MaterialsList.AutoGenerateColumns = false;
            MaterialsList.ItemsSource = MyMaterials;
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
            if (MaterialsList.SelectedItem is Materialy selectedMaterial)
            {
                MessageBoxResult result = MessageBox.Show("Czy jesteś pewien, że chcesz usunąć ten rekord?", "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (ProductXpertContext _context = new ProductXpertContext())
                    {
                        var materialToRemove = _context.Materialy.FirstOrDefault(m => m.IdMaterialu == selectedMaterial.IdMaterialu);
                        if (materialToRemove != null)
                        {
                            _context.Materialy.Remove(materialToRemove);
                            _context.SaveChanges();
                        }
                    }
                }
            }
            Refresh();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nametxt.Text) || string.IsNullOrEmpty(desctxt.Text) || string.IsNullOrEmpty(pricetxt.Text) || string.IsNullOrEmpty(weighttxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie komórki panelu dodawania rekordu do bazy!");
            }
            else
            {
                Materialy newMaterial = new Materialy
                {
                    Nazwa = nametxt.Text,
                    Opis = desctxt.Text,
                    Cena = Convert.ToDecimal(pricetxt.Text),
                    Waga = Convert.ToDecimal(weighttxt.Text)
                };

                using (ProductXpertContext _context = new ProductXpertContext())
                {
                    _context.Materialy.Add(newMaterial);
                    _context.SaveChanges();
                }
                Refresh();

                nametxt.Text = "";
                desctxt.Text = "";
                pricetxt.Text = "";
                weighttxt.Text = "";
            }
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(selecttxt.Text))
            {
                MessageBox.Show("Uzupełnij nazwę, po której chcesz wyszukać produkt!");
            }
            else
            {
                using (ProductXpertContext _context = new ProductXpertContext())
                {
                    MyMaterials = _context.Materialy
                        .Where(m => m.Nazwa == selecttxt.Text)
                        .Select(m => new Materialy
                        {
                            IdMaterialu = m.IdMaterialu,
                            Nazwa = m.Nazwa,
                            Opis = m.Opis,
                            Cena = m.Cena,
                            Waga = m.Waga
                        })
                        .ToList();
                }

                MaterialsList.AutoGenerateColumns = false;
                MaterialsList.ItemsSource = MyMaterials;
                selecttxt.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
