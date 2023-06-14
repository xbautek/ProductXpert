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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        public List<Order> MyOrders { get; set; }

        public Orders()
        {
            InitializeComponent();

            using (ProductXpertContext _context = new ProductXpertContext())
            {
                MyOrders = _context.Orders
                    .Join(_context.Customers, o => o.CustomerId, c => c.CustomerId, (o, c) => new { Order = o, Customer = c })
                    .Join(_context.Products, oc => oc.Order.ProductId, p => p.ProductId, (oc, p) => new Order
                    {
                        OrderId = oc.Order.OrderId,
                        CompanyName = oc.Customer.CompanyName,
                        ProductName = p.ProductName,
                        OrderDate = oc.Order.OrderDate,
                        Amount = oc.Order.Amount,
                        OrderStatus = oc.Order.OrderStatus
                    })
                    .Select(o => new Order
                    {
                        OrderId = o.OrderId,
                        CompanyName = o.CompanyName,
                        ProductName = o.ProductName,
                        OrderDate = o.OrderDate,
                        Amount = o.Amount,
                        OrderStatus = o.OrderStatus
                    })
                    .ToList();
            }

            orderslist.AutoGenerateColumns = false;
            orderslist.ItemsSource = MyOrders;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime date;
                if (string.IsNullOrEmpty(companynametxt.Text) || string.IsNullOrEmpty(productnametxt.Text) || string.IsNullOrEmpty(datetxt.Text) || string.IsNullOrEmpty(amounttxt.Text) || string.IsNullOrEmpty(statustxt.Text))
                {
                    MessageBox.Show("Uzupełnij wszystkie komórki panelu dodawania rekordu do bazy!");
                }
                else if (!DateTime.TryParse(datetxt.Text, out date))
                {
                    MessageBox.Show("Zły format daty!");
                }
                else
                {
                    // Pobierz dane z formularza
                    string companyName = companynametxt.Text;
                    string productName = productnametxt.Text;
                    int amount = int.Parse(amounttxt.Text);
                    string status = statustxt.Text;

                    using (ProductXpertContext _context = new ProductXpertContext())
                    {
                        // Pobierz firme na podstawie jej nazwy
                        Customer? customer = _context.Customers.FirstOrDefault(c => c.CompanyName == companyName);
                        // Pobierz produkt na podstawie jego nazwy
                        Product? product = _context.Products.FirstOrDefault(p => p.ProductName == productName);


                        //MessageBox.Show($"{material.MaterialId}");
                        if (customer != null && product != null)
                        {
                            // Utwórz nowy obiekt produktu
                            Order newOrder = new Order
                            {
                                ProductId = product.ProductId,
                                OrderDate = date,
                                Amount = amount,
                                OrderStatus = status,
                                CustomerId = customer.CustomerId // Przypisz ID materiału do właściwości MaterialId produktu
                            };

                            // Dodaj produkt do kontekstu i zapisz zmiany w bazie danych
                            _context.Orders.Add(newOrder);
                            _context.SaveChanges();

                            // Odśwież listę produktów
                            Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono firmy bądź produktu o podanej nazwie.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
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

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selecttxt.Text))
                {
                    MessageBox.Show("Wprowadź nazwe produktu!");
                }
                else
                {
                    using (ProductXpertContext _context = new ProductXpertContext())
                    {
                        MyOrders = _context.Orders
                            .Join(_context.Customers, o => o.CustomerId, c => c.CustomerId, (o, c) => new { Order = o, Customer = c })
                            .Join(_context.Products, oc => oc.Order.ProductId, p => p.ProductId, (oc, p) => new Order
                            {
                                OrderId = oc.Order.OrderId,
                                CompanyName = oc.Customer.CompanyName,
                                ProductName = p.ProductName,
                                OrderDate = oc.Order.OrderDate,
                                Amount = oc.Order.Amount,
                                OrderStatus = oc.Order.OrderStatus
                            })
                            .Where(p => p.ProductName == selecttxt.Text)
                            .Select(o => new Order
                            {
                                OrderId = o.OrderId,
                                CompanyName = o.CompanyName,
                                ProductName = o.ProductName,
                                OrderDate = o.OrderDate,
                                Amount = o.Amount,
                                OrderStatus = o.OrderStatus
                            })
                            .ToList();
                    }

                    orderslist.AutoGenerateColumns = false;
                    orderslist.ItemsSource = MyOrders;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd!");
            }
            
   
        }

        private void Select()
        {
            try
            {
                if (string.IsNullOrEmpty(selecttxt.Text))
                {
                    MessageBox.Show("Wprowadź nazwe produktu!");
                }
                else
                {
                    using (ProductXpertContext _context = new ProductXpertContext())
                    {
                        MyOrders = _context.Orders
                            .Join(_context.Customers, o => o.CustomerId, c => c.CustomerId, (o, c) => new { Order = o, Customer = c })
                            .Join(_context.Products, oc => oc.Order.ProductId, p => p.ProductId, (oc, p) => new Order
                            {
                                OrderId = oc.Order.OrderId,
                                CompanyName = oc.Customer.CompanyName,
                                ProductName = p.ProductName,
                                OrderDate = oc.Order.OrderDate,
                                Amount = oc.Order.Amount,
                                OrderStatus = oc.Order.OrderStatus
                            })
                            .Where(p => p.ProductName == selecttxt.Text)
                            .Select(o => new Order
                            {
                                OrderId = o.OrderId,
                                CompanyName = o.CompanyName,
                                ProductName = o.ProductName,
                                OrderDate = o.OrderDate,
                                Amount = o.Amount,
                                OrderStatus = o.OrderStatus
                            })
                            .ToList();

                        orderslist.AutoGenerateColumns = false;
                        orderslist.ItemsSource = MyOrders;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd!");
            }
            
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                MyOrders = _context.Orders
                    .Join(_context.Customers, o => o.CustomerId, c => c.CustomerId, (o, c) => new { Order = o, Customer = c })
                    .Join(_context.Products, oc => oc.Order.ProductId, p => p.ProductId, (oc, p) => new Order
                    {
                        OrderId = oc.Order.OrderId,
                        CompanyName = oc.Customer.CompanyName,
                        ProductName = p.ProductName,
                        OrderDate = oc.Order.OrderDate,
                        Amount = oc.Order.Amount,
                        OrderStatus = oc.Order.OrderStatus
                    })
                    .Select(o => new Order
                    {
                        OrderId = o.OrderId,
                        CompanyName = o.CompanyName,
                        ProductName = o.ProductName,
                        OrderDate = o.OrderDate,
                        Amount = o.Amount,
                        OrderStatus = o.OrderStatus
                    })
                    .ToList();
            }

            orderslist.AutoGenerateColumns = false;
            orderslist.ItemsSource = MyOrders;
        }

        private void Refresh()
        {
            using (ProductXpertContext _context = new ProductXpertContext())
            {
                MyOrders = _context.Orders
                    .Join(_context.Customers, o => o.CustomerId, c => c.CustomerId, (o, c) => new { Order = o, Customer = c })
                    .Join(_context.Products, oc => oc.Order.ProductId, p => p.ProductId, (oc, p) => new Order
                    {
                        OrderId = oc.Order.OrderId,
                        CompanyName = oc.Customer.CompanyName,
                        ProductName = p.ProductName,
                        OrderDate = oc.Order.OrderDate,
                        Amount = oc.Order.Amount,
                        OrderStatus = oc.Order.OrderStatus
                    })
                    .Select(o => new Order
                    {
                        OrderId = o.OrderId,
                        CompanyName = o.CompanyName,
                        ProductName = o.ProductName,
                        OrderDate = o.OrderDate,
                        Amount = o.Amount,
                        OrderStatus = o.OrderStatus
                    })
                    .ToList();
            }

            orderslist.AutoGenerateColumns = false;
            orderslist.ItemsSource = MyOrders;
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (orderslist.SelectedItem is Order selectedProduct)
                {
                    MessageBoxResult result = MessageBox.Show("Czy jesteś pewien, że chcesz usunąć ten rekord?", "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        using (ProductXpertContext _context = new ProductXpertContext())
                        {
                            var productToRemove = _context.Orders.FirstOrDefault(o => o.OrderId == selectedProduct.OrderId);
                            if (productToRemove != null)
                            {
                                _context.Orders.Remove(productToRemove);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
                Refresh();
            }
            catch
            {
                MessageBox.Show("Błąd!");
            }
            
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
