using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaire_Heritage_Simple
{
    class Entreprises
    {
        public String Nom { get; set; }
        public List<Commerciaux> ListeCommerciaux { get; set; }
        public List<Techniciens> ListeTechniciens { get; set; }


        public Entreprises(string nom)
        {
            Nom = nom;
            ListeCommerciaux = new List<Commerciaux>();
            ListeTechniciens = new List<Techniciens>();
        }

        public void Embaucher(AbstractEmployes e)
        {
            switch (e.GetType().Name) // en fonction du type
            {
                case "Commerciaux": ListeCommerciaux.Add((Commerciaux)e); break;   // le cast permet de forcer l'employes à être de type commerciaux
                case "Vendeurs": ListeCommerciaux.Add((Vendeurs)e); break;
                case "Representants": ListeCommerciaux.Add((Representants)e); break;
                case "Techniciens": ListeTechniciens.Add((Techniciens)e); break;
                case "Interimaires": ListeTechniciens.Add((Interimaires)e); break;
                default: break;
            }

        }

        public void Licencier(AbstractEmployes e)
        {
            switch (e.GetType().Name) // en fonction du type
            {
                case "Commerciaux": ListeCommerciaux.Remove((Commerciaux)e); break;   // le cast permet de forcer l'employes à être de type commerciaux
                case "Vendeurs": ListeCommerciaux.Remove((Vendeurs)e); break;
                case "Representants": ListeCommerciaux.Remove((Representants)e); break;
                case "Techniciens": ListeTechniciens.Remove((Techniciens)e); break;
                case "Interimaires": ListeTechniciens.Remove((Interimaires)e); break;
                default: break;
            }
        }
        public Double MasseSalariale()
        {
            Double masseSalariale = 0;
            // on crée une liste qui append les 2 autres pour limiter le nombre de foreach
            List<AbstractEmployes> liste = new List<AbstractEmployes>();
            liste.AddRange(ListeCommerciaux);
            liste.AddRange(ListeTechniciens);
            foreach (var comm in liste)
            {
                masseSalariale += comm.CalculSalaire();
            }
            return masseSalariale;
        }
        public override string ToString()
        {
            String presentation = "";
            presentation += "Répartition des salaires\n\n";
            presentation += "\n COMMERCIAUX";
            foreach (var comm in ListeCommerciaux)
            {
                presentation += "\n\t " + comm;
            }
            presentation += "\n\n TECHNICIENS";
            foreach (var tech in ListeTechniciens)
            {
                presentation += "\n\t " + tech;
            }
            return presentation + "\n\n soit un total de " + MasseSalariale();
        }
    }

}
