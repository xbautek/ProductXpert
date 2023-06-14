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
        private bool doornot = false;

        public Settings()
        {
            InitializeComponent();

            doornot = false;
            MajorWindow mainWindow = FindMajorWindow();

            if(!doornot)
                if (mainWindow != null)
                     if (mainWindow.calculator.Visibility != Visibility.Visible)
                          calccheck.IsChecked = true;

            doornot = true;

        }

        private MajorWindow FindMajorWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is MajorWindow majorWindow)
                {
                    return majorWindow;
                }
            }

            return null;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(doornot)
            {
                Window parentWindow = Window.GetWindow(this);
                Button? calculatorButton = parentWindow.FindName("calculator") as Button;

                if (calculatorButton != null)
                {
                    calculatorButton.Visibility = Visibility.Collapsed; // lub Visibility.Visible w zależności od potrzeb
                    calculatorButton.IsEnabled = false;
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (doornot)
            {
                Window parentWindow = Window.GetWindow(this);
                Button? calculatorButton = parentWindow.FindName("calculator") as Button;

                if (calculatorButton != null)
                {
                    calculatorButton.Visibility = Visibility.Visible;
                    calculatorButton.IsEnabled = true;
                }
            }   
        }      
    }
}
