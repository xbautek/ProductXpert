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
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Content = new Home();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Content = new Orders();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
