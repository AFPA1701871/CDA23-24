using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaire_Heritage_Simple
{
    class Employes
    {
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int Age { get; set; }
        public Double Salaire { get; set; }


        public Employes(string nom, String prenom, int age, Double salaire)
        {
            Nom = nom;
            Prenom = prenom;
            Age = age;
            Salaire = salaire;
        }

        public virtual Double CalculSalaire() // on ajoute virtual pour pouvoir implémenter la méthode différemment dans les enfants
        {
            return Salaire;
        }

        public override string ToString()
        {
            return this.GetType() + "\tNom : " + Nom + "\tPrenom : " + Prenom + "\tAge : " + Age + "\tSalaire : " + CalculSalaire();

            // getType() permet de récupérer le type de l'objet
            // on peut aussi utiliser base.ToString()
        }
        public void Afficher()
        {
            Console.WriteLine(this);
        }
    }
}
