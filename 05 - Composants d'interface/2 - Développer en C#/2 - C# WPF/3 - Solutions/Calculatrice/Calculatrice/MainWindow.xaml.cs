using System;
using System.Collections.Generic;
using System.Data;
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
        public bool valid = false; // contient vrai si le calcul est valide (1 opérande et 1 opérateur au moins), l'appui sur le prochain num activera le egal
        public bool noComa = true; // contient vrai tant qu'il n'y a pas de virgule dans l'opérande en cours de saisie

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ((Window)sender).Width = 0.75 * ((Window)sender).ActualHeight;
        }


        //-----------------------Event-----------------------------------------
        private void Btn_Num_Click(object sender, RoutedEventArgs e)
        { // Méthode déclenchée à chaque clic sur l'un des boutons numériques
            lblAfficheur.Content += (string)((Button)sender).Content; // On ajoute le contenu du bouton sur lequel on vient de cliquer
            Btn_Ope_Activation();// on active les boutons opérateurs
            if (valid) btnEgal.IsEnabled = true; // si on est à la saisie de la 2eme opérande, on active le egal
        }

        private void Btn_Op_Click(object sender, RoutedEventArgs e)
        {// Méthode déclenchée à chaque clic sur l'un des boutons opérateurs
            lblAfficheur.Content += (string)((Button)sender).Content; // On ajoute le contenu du bouton sur lequel on vient de cliquer

            noComa = true; // on réinitialise les virgules
            valid = true;

            // on désactive les opérateurs, la virgule et le égal
            Btn_Ope_Desactivation(); 
            btnVirgule.IsEnabled = false;
            btnEgal.IsEnabled = false;
        }

        private void Btn_Coma_Click(object sender, RoutedEventArgs e)
        {// Méthode déclenchée à chaque clic sur la virgule
            lblAfficheur.Content += (string)((Button)sender).Content;

            noComa = false;

            // on désactive les opérateurs, la virgule et le égal
            Btn_Ope_Desactivation(); 
            btnVirgule.IsEnabled = false;
            btnEgal.IsEnabled = false;
        }

       
        //--------------------Button hidder----------------------------

        private void Btn_Ope_Activation()
        { // Méthode qui active les boutons opérateurs et la virgule si possible
            if (noComa) btnVirgule.IsEnabled = true;

            btnPlus.IsEnabled = true;
            btnMoins.IsEnabled = true;
            btnDivise.IsEnabled = true;
            btnMultiplie.IsEnabled = true;
        }

        private void Btn_Ope_Desactivation()
        {// Méthode qui desactive les boutons opérateurs 
            btnPlus.IsEnabled = false;
            btnMoins.IsEnabled = false;
            btnDivise.IsEnabled = false;
            btnMultiplie.IsEnabled = false;
        }


        //--------------------Special button----------------------------

        private void ButtonEQUALS_Click(object sender, RoutedEventArgs e)
        { // Méthode déclenchée par le clic sur le bouton égal
            valid = false;

            var res = Convert.ToString(lblAfficheur.Content);
            res = res.Replace(",", ".");
            var dt = new DataTable();

            lblAfficheur.Content = dt.Compute(res, string.Empty);  // Méthode qui évalue le calcul passé en paramètre
        }

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        { //Méthode qui réinitialise le calcul
            lblAfficheur.Content = "";
            valid = false;

            Btn_Ope_Desactivation();
            btnVirgule.IsEnabled = false;
            btnEgal.IsEnabled = false;
        }
    }
}
