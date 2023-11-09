using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Employe.Program;

namespace Employe
{
    class Employes
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateEmbauche { get; set; }
        public string Fonction { get; set; }
        public double Salaire { get; set; }
        public string Service { get; set; }
        public Agences Agence { get; set; }
        public List<Enfants> ListeEnfants { get; set; } = new List<Enfants>();

        public Employes(string nom, string prenom, DateTime dateEmbauche, string fonction, double salaire, string service, Agences agence, List<Enfants> listeEnfants)
        {
            Nom = nom;
            Prenom = prenom;
            DateEmbauche = dateEmbauche;
            Fonction = fonction;
            Salaire = salaire;
            Service = service;
            Agence = agence;
            ListeEnfants = listeEnfants;
        }
        public Employes(string nom, string prenom, DateTime dateEmbauche, string fonction, double salaire, string service, Agences agence)
        {
            Nom = nom;
            Prenom = prenom;
            DateEmbauche = dateEmbauche;
            Fonction = fonction;
            Salaire = salaire;
            Service = service;
            Agence = agence;
        }

        public int NbAnneesAnciennete()
        {
            TimeSpan ecart = DateTime.Today - DateEmbauche;
            //Nombre d'années dans l'entreprise

            //Autre méthode en passant par un DateTime
            //DateTime zero = new DateTime(1, 1, 1);
            //int annee = (zero.AddDays(ecart.TotalDays)).Year-1;

            int annee = (int)(ecart.TotalDays / 365);
            return (annee);
        }

        public double PrimeSalaire()
        {
            return this.Salaire * 0.05;
        }

        public double PrimeAnciennete()
        {
            return this.Salaire * 0.02 * this.NbAnneesAnciennete();
        }
        public double Prime()
        {
            return Math.Round(this.PrimeSalaire() + this.PrimeAnciennete(), 2); // on arrondi 2 chiffres après la virgule
        }
        /// <summary>
        /// Méthode théorique : en réalité la méthode serait déplacer en dehors de la classe Employes
        /// </summary>
        public void OrdreDeTransfert()
        {
            DateTime dateVersement = new DateTime(DateTime.Now.Year, 11, 30); // DateTime.Now.Year donne l'année du jour en cours
            if (DateTime.Now == dateVersement)  // peut être modifié par une comparaison de mois et jour uniquement
            {
                Console.WriteLine("Ordre de transfert de " + this.Prime() + "pour la salarié " + this.Nom);
            }
        }

        public static int ClassementNom(Employes a, Employes b)
        {
            if (a.Nom.CompareTo(b.Nom) > 0)
            {
                return 1;
            }
            else if (a.Nom.CompareTo(b.Nom) < 0)
            {
                return -1;
            }
            else if (a.Prenom.CompareTo(b.Prenom) > 0) // les noms sont égaux, on compare les prenoms
            {
                return 1;
            }
            else if (a.Prenom.CompareTo(b.Prenom) < 0)
            {
                return -1;
            }
            else
            {
                return 0; // noms et prenoms egaux
            }
        }
        public static int ClassementService(Employes a, Employes b)
        {
            if (a.Service.CompareTo(b.Service) > 0)
            {
                return 1;
            }
            else if (a.Service.CompareTo(b.Service) < 0)
            {
                return -1;
            }
            return ClassementNom(a, b); // si les services sont égaux, on renvoi la comparaison par Nom
        }

        public double MasseSalariale()
        {
            return this.Salaire + this.Prime();
        }

        public string ChequeVac()
        {
            if (this.NbAnneesAnciennete() >= 1)
            {
                return "L'employe bénéficie de chèques vacances";
            }
            return "L'employe ne bénéficie pas de chèques vacances";

        }

        public void AjouterEnfant(Enfants enfant)
        {
            this.ListeEnfants.Add(enfant);
        }

        public string ChequeNoel()
        {
            int[] tab = new int[3] { 0, 0, 0 }; // on stocke le nombre de chèque de chaque montant
            string reponse = "";
            foreach (var enfant in ListeEnfants)
            {
                switch (enfant.ChequeNoel())
                {
                    case 20: tab[0]++; break;
                    case 30: tab[1]++; break;
                    case 50: tab[2]++; break;
                    default: break;
                }

            }
            if (tab.Sum() == 0)  // tab.Sum fait la somme de toutes les cases du tableau
            {
                return "Pas de droit aux chèques Noel";
            }
            if (tab[0] > 0) reponse += tab[0] + " chèque de 20\n";
            if (tab[1] > 0) reponse += tab[1] + " chèque de 30\n";
            if (tab[2] > 0) reponse += tab[2] + " chèque de 50\n";
            return reponse;
        }

        public string ChequeNoel2()
        {
            int[] tab = new int[3] { 0, 0, 0 }; // on stocke le nombre de chèque de chaque montant
            string reponse = "";

            // parcours des enfants pour connaitre les valeurs des cheques
            foreach (var enfant in ListeEnfants)
            {
                tab[(int)enfant.ChequeNoel2()]++;   // en fonction de la réponse de chequeNoel enfant, on incremente la case du tableau correspondante
                // enfant.ChequeNoel2() renvoi par exemple C20, caster en int donne 0 (car le 1er de l'enumeration)
            }


            if (tab.Sum() == 0)  // tab.Sum fait la somme de toutes les cases du tableau
            {
                return "Pas de droit aux chèques Noel";
            }
            // comme la partie vrai contient un return, le reste ne s'execute que s'il a droit aux cheques Noel
            for (var i = 0; i < tab.Length; i++)
            { // on parcours le tableau pour connaitre le nb de cheque à distribuer
                if (tab[i] > 0) reponse += tab[i] + " chèque de " + (Enum.GetName(typeof(ValeurChequeNoel), i)).Substring(1) + "\n";

                // pour recuperer la valeur du cheque on cherche à obtenir C20 et on enleve le C
                // Enum.GetName(typeof(ValeurChequeNoel), i) permet de récuperer le libellé associé à la valeur i
                // .Substring(1) permet d'enlever le C
            }

            return reponse;
        }
        public override string ToString()
        {

            string reponse =
            "****_INFORMATION_SUR_L'EMPLOYES_****" +
            "\n|Nom                : " + this.Nom +
            "\n|Prenom           : " + this.Prenom +
            "\n|Date Embauche    : " + this.DateEmbauche.ToString("dd/MM/yyyy") +  // on formate la date avant l'affichage
            "\n|Fonction         : " + this.Fonction +
            "\n|Salaire          : " + this.Salaire +
            "\n|Service          : " + this.Service +
            "\n|" + this.ChequeVac() +
            "\n|" + this.ChequeNoel() +
            "\nsolution 2\n" +
            "\n|" + this.ChequeNoel2() +

            this.Agence;
            return reponse;
        }
    }
}
