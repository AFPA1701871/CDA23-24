using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplePOO
{
     class Personnes
    {
        // exemple de propriété
        public string MaChaine { get; set; } 
        public int IdPersonne { get; set; }
        // exemple d'attribut
        private int idClass;

        // différents constructeurs
        public Personnes(string maChaine)
        {
            MaChaine = maChaine;
        }
        public Personnes()
        {
                
        }
        public Personnes(int idClass)
        {
            this.SetIdClass(idClass);
        }

        public Personnes(string maChaine, int idPersonne, int idClass) : this(maChaine)
        {
            IdPersonne = idPersonne;
            this.idClass = idClass;
        }

        // getters et setters technique 1
        //public int IdClass { get => idClass; set => idClass = value-1; }


        // getters et setters technique 2
        public int GetIdClass()
        {
            return idClass;
        }

        public void SetIdClass(int value)
        {
            idClass = value;
        }

        public override string ToString()
        {
            return "Personne :  idClass : " + GetIdClass() + "  IdPersonne : " + IdPersonne + "  maChaine : " + MaChaine;
        }
    }
}
