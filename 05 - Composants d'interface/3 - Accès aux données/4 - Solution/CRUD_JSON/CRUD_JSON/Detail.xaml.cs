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

namespace CRUD_JSON
{
    /// <summary>
    /// Logique d'interaction pour Detail.xaml
    /// </summary>
    public partial class Detail : Window
    {
        public string Mode { get; set; }

        public Detail(Produits p , MainWindow w, string mode)
        {
            InitializeComponent();
            Mode = mode;
            valider.Content = Mode;
            RemplissageChamp(p);
        }
        public void RemplissageChamp(Produits p)
        {
            if (Mode != "Ajouter")
            {
                libelleProduit.Text = p.LibelleProduit;
                idProduit.Content = p.IdProduit.ToString();
                numeroProduit.Text = p.NumeroProduit.ToString();
                quantite.Text = p.Quantite.ToString();
            }
            else
            {
                idProduit.Content = "0";
            }
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            Produits p = new Produits(Int32.Parse((string)idProduit.Content), libelleProduit.Text, Int32.Parse(numeroProduit.Text), Int32.Parse(quantite.Text));
            switch (Mode)
            {
                case "Ajouter": ProduitsServices.AddProduit(p); break;
                case "Modifier": ProduitsServices.UpdateProduit(p); break;
                case "Supprimer": ProduitsServices.DeleteProduit(p); break;
            }
            this.Close();
        }
        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
