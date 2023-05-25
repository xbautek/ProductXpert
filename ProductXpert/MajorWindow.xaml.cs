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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProductXpert.ViewModel;

namespace ProductXpert
{
    /// <summary>
    /// Interaction logic for MajorWindow.xaml
    /// </summary>
    public partial class MajorWindow : Window
    {
        public MajorWindow()
        {
            InitializeComponent();
            var home = new Home();

            // Dodawanie kontrolki do kontenera
            ContentContainer.Content = home;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Home_Click(object sender, RoutedEventArgs e)
        {
            // Tworzenie nowej instancji UserControl
            var home = new Home();

            // Dodawanie kontrolki do kontenera
            ContentContainer.Content = home;

            // Ustawianie początkowej wartości przezroczystości
            home.Opacity = 0;

            // Tworzenie storyboardu animacji
            var storyboard = new Storyboard();
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            Storyboard.SetTarget(fadeInAnimation, home);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(fadeInAnimation);

            // Uruchamianie animacji
            storyboard.Begin();

            // Czekanie przez określony czas
            await Task.Delay(1000);

            // Zatrzymywanie animacji
            //storyboard.Stop();
        }

        private async void Orders_Click(object sender, RoutedEventArgs e)
        {
            var orders = new Orders();
            ContentContainer.Content = orders;
            orders.Opacity = 0;
            var storyboard = new Storyboard();
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            Storyboard.SetTarget(fadeInAnimation, orders);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(fadeInAnimation);
            storyboard.Begin();
            await Task.Delay(1000);
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private async void Products_Click(object sender, RoutedEventArgs e)
        {
            var products = new Products();
            ContentContainer.Content = products;
            products.Opacity = 0;

            var storyboard = new Storyboard();
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            Storyboard.SetTarget(fadeInAnimation, products);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(fadeInAnimation);

            storyboard.Begin();
            await Task.Delay(1000);
        }

        private async void ToDo_Click(object sender, RoutedEventArgs e)
        {
            var todo = new ToDo();
            ContentContainer.Content = todo;
            todo.Opacity = 0;

            var storyboard = new Storyboard();
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            Storyboard.SetTarget(fadeInAnimation, todo);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(fadeInAnimation);

            storyboard.Begin();
            await Task.Delay(1000);
        }

        private async void Materials_Click(object sender, RoutedEventArgs e)
        {
            var materials = new Materials();

            ContentContainer.Content = materials;

            materials.Opacity = 0;

            var storyboard = new Storyboard();
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            Storyboard.SetTarget(fadeInAnimation, materials);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(fadeInAnimation);

            storyboard.Begin();
            await Task.Delay(1000);
        }

        private async void Clients_Click(object sender, RoutedEventArgs e)
        {
            var clients = new Clients();

            ContentContainer.Content = clients;

            clients.Opacity = 0;

            var storyboard = new Storyboard();
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            Storyboard.SetTarget(fadeInAnimation, clients);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(fadeInAnimation);

            storyboard.Begin();
            await Task.Delay(1000);
        }

        private async void Calculator_Click(object sender, RoutedEventArgs e)
        {
            var calc = new Calculator();

            ContentContainer.Content = calc;

            calc.Opacity = 0;

            var storyboard = new Storyboard();
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            Storyboard.SetTarget(fadeInAnimation, calc);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(fadeInAnimation);

            storyboard.Begin();
            await Task.Delay(1000);
        }

        private async void Settings_Click(object sender, RoutedEventArgs e)
        {
            var sett = new Settings();

            ContentContainer.Content = sett;

            sett.Opacity = 0;

            var storyboard = new Storyboard();
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            Storyboard.SetTarget(fadeInAnimation, sett);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(OpacityProperty));
            storyboard.Children.Add(fadeInAnimation);

            storyboard.Begin();
            await Task.Delay(1000);
        }
    }
}
