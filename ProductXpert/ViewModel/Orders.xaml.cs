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

            // Initialize the MyOrders list with data from the database
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

            // Configure the data grid to display the orders
            orderslist.AutoGenerateColumns = false;
            orderslist.ItemsSource = MyOrders;
        }

        // Event handler for the Add button click
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate the input fields
                DateTime date;
                if (string.IsNullOrEmpty(companynametxt.Text) || string.IsNullOrEmpty(productnametxt.Text) || string.IsNullOrEmpty(datetxt.Text) || string.IsNullOrEmpty(amounttxt.Text) || string.IsNullOrEmpty(statustxt.Text))
                {
                    MessageBox.Show("Please fill in all the fields in the record adding panel!");
                }
                else if (!DateTime.TryParse(datetxt.Text, out date))
                {
                    MessageBox.Show("Invalid date format!");
                }
                else
                {
                    // Parse the input values
                    string companyName = companynametxt.Text;
                    string productName = productnametxt.Text;
                    int amount = int.Parse(amounttxt.Text);
                    string status = statustxt.Text;
                    DateTime datee = DateTime.Parse(datetxt.Text);

                    // Add the new order to the database
                    using (ProductXpertContext _context = new ProductXpertContext())
                    {
                        Customer? customer = _context.Customers.FirstOrDefault(c => c.CompanyName == companyName);
                        Product? product = _context.Products.FirstOrDefault(p => p.ProductName == productName);

                        if (customer != null && product != null)
                        {
                            Order newOrder = new Order
                            {
                                ProductId = product.ProductId,
                                OrderDate = datee,
                                Amount = amount,
                                OrderStatus = status,
                                CustomerId = customer.CustomerId
                            };

                            _context.Orders.Add(newOrder);
                            _context.SaveChanges();

                            Refresh();
                        }
                        else
                        {
                            MessageBox.Show("No company or product found with the given name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler for the Select button click
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selecttxt.Text))
                {
                    MessageBox.Show("Please enter a product name!");
                }
                else
                {
                    // Select orders with the specified product name from the database
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

                    // Display the selected orders in the data grid
                    orderslist.AutoGenerateColumns = false;
                    orderslist.ItemsSource = MyOrders;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        // Refreshes the data grid with all orders
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

        // Refreshes the data grid with all orders
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

        // Deletes the selected order from the data grid and database
        private void Delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (orderslist.SelectedItem is Order selectedProduct)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                MessageBox.Show("Error!");
            }
        }

        // Event handler for the Escape key press in the data grid
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