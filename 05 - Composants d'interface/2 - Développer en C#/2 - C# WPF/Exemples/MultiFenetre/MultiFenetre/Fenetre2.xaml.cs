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

namespace MultiFenetre
{
    /// <summary>
    /// Logique d'interaction pour Fenetre2.xaml
    /// </summary>
    public partial class Fenetre2 : Window
    {
        public Fenetre2(MainWindow w, string mot)
        {
            InitializeComponent();
       
            lblMot.Content = mot;   
        }
    }
}
