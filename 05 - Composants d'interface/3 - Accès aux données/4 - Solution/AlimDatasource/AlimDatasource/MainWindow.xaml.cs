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

namespace AlimDatasource
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Liste.Add(new Article(1, "ciseaux", 6, 1, "categ un"));
            Liste.Add(new Article(2, "règle 30 cm", 4, 2,  "categ 2"));
            dgProduits.ItemsSource = Liste;
        }
        public List<Article> Liste { get; set; }=new List<Article>();

    }
}
