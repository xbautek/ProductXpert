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
    }
}
