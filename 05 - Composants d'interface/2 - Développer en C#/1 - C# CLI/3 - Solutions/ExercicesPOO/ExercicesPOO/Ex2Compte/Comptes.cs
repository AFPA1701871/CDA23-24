using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO.Ex2Compte
{
    class Comptes
    {
        public double Solde { get; private set; }   // pour mettre une propriété en lecture seule, on ajoute private devant set,
                                                    // le setteur ne pourra pas être appelé depuis l'extérieur
                                                    // donc la propriété ne sera pas modifiable depuis l'extérieur
        public int Code { get; private set; }
        public Clients Proprietaire { get; set; }

        private static int NbrDeCompte { get; set; } = 0;  // permet de compter les comptes créés. La propriété sera incrémenté avec chaque constructeur

        public Comptes(Clients proprietaire)
        {
            Code = ++NbrDeCompte;
            this.Proprietaire = proprietaire;
            this.Solde = 0;     // on définit la valeur par défaut
        }

        /// <summary>
        /// Permet de créditer le compte du montant passé en paramètre
        /// </summary>
        /// <param name="somme">Montant à créditer</param>
        public void Crediter(double somme)
        {
            this.Solde += somme;
        }
        /// <summary>
        /// Permet de créditer le compte du montant passé en paramètre et débite le compte passé en paramètre
        /// </summary>
        /// <param name="somme">Montant à créditer</param>
        /// <param name="compte">Compte à débiter</param>
        /// <returns>Renvoi vrai si le traitement s'est bien passé</returns>
        public bool Crediter(double somme, Comptes compteADebiter)
        {
            this.Crediter(somme);  // équivalent à  this.Solde += somme;
            compteADebiter.Debiter(somme);
            return true;
        }
        public void Debiter(double somme)
        {
            this.Solde -= somme;
        }
        
        public void Debiter(double somme, Comptes compte)
        {
            this.Debiter(somme);
            compte.Crediter(somme);
        }
        public override string ToString()
        {
            return this.Proprietaire + "| Code: " + this.Code + "| Solde: " + this.Solde;
        }
        public void Afficher()
        {
            Console.WriteLine(this);
        } 
        
        public static void afficherNbrDeCompte()  // méthode static parce qu'elle appele une propriété static
        {
            Console.WriteLine("nombre de compte crées: " + NbrDeCompte);
        }
    }
}
