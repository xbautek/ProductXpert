using ProductXpert.Class;
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
    /// Interaction logic for ToDo.xaml
    /// </summary>
    public partial class ToDo : UserControl
    {
        public List<Product> MyProducts { get; set; }

        public ToDo()
        {
            InitializeComponent();

            using (ProductXpertContext _context = new ProductXpertContext())
            {
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
                    .Where(p => p.MinimalAmount >= p.Amount)
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

        

        private void Refresh()
        {
            using (ProductXpertContext _context = new ProductXpertContext())
            {
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
