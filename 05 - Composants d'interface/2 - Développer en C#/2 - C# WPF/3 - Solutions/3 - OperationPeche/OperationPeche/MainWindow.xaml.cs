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

namespace OperationPeche
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Carac> users = new List<Carac>();
            users.Add(new Carac() {  Caracteristique = "Déroulement de l'activité", Valeur = "Normal", Unite="aucune",Support="navire",Fraction="totale", Methode="Observation par Observateur" });
            users.Add(new Carac() {  Caracteristique = "Etat de la mer", Valeur = "2 - belle, vagues", Unite = "aucune", Support = "masse d'eau", Fraction = "totale", Methode = "Observation par Observateur" });
            users.Add(new Carac() { Caracteristique = "Opération diurne (jour)?", Unite = "aucune", Support = "opération", Fraction = "totale", Methode = "Observation par Observateur" }); 
            users.Add(new Carac() { Caracteristique = "Nature du fond", Unite = "aucune", Support = "substrat", Fraction = "totale", Methode = "Déclaration d'un professionnel" });

            Caracteristiques.ItemsSource = users;
        }
        class Carac
        {
            public string Caracteristique{ get; set; }
            public string Valeur { get; set; }
            public string Unite { get; set; }
            public string Support { get; set; }
            public string Fraction { get; set; }
            public string Methode { get; set; }

        }

       
    }
}
