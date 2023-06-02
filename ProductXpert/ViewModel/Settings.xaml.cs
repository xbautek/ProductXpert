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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            Button calculatorButton = parentWindow.FindName("calculator") as Button;

            if (calculatorButton != null)
            {
                calculatorButton.Visibility = Visibility.Collapsed; // lub Visibility.Visible w zależności od potrzeb
                calculatorButton.IsEnabled = false;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            Button calculatorButton = parentWindow.FindName("calculator") as Button;

            if (calculatorButton != null)
            {
                calculatorButton.Visibility = Visibility.Visible;
                calculatorButton.IsEnabled = true;
            }
        }
    }
}
