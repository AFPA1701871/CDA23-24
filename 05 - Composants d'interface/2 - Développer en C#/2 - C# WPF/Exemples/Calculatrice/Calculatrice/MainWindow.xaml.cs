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

namespace Calculatrice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblAfficheur.Content = "";
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Faire apparaitre les tailles dans la sortie
            ((Window)sender).ActualHeight.Dump();
            ((Window)sender).ActualWidth.Dump();

            ((Window)sender).Height=4/3* ((Window)sender).ActualWidth; // garder les proportions



        }

        /*private void btn1_Click(object sender, RoutedEventArgs e)
        {
            lblAfficheur.Content += "1";
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            lblAfficheur.Content += "2";
        }
        */
        private void btnNum_Click(object sender, RoutedEventArgs e)
        {
            lblAfficheur.Content += (string)((Button)sender).Content;
        }

      
    }
}
