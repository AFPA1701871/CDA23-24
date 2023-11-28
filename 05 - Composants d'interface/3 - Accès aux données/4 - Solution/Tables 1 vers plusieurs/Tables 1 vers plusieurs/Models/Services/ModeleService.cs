using Microsoft.EntityFrameworkCore;
using Tables_1_vers_plusieurs.Models.Data;

namespace Tables_1_vers_plusieurs.Models.Services
{
    public class ModeleService
    {
        
        private readonly VoitureContext _context;

        public ModeleService    (VoitureContext context)
        {
            _context = context;
        }

        public void AddModele(Modele v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v));
            }
            _context.Modeles.Add(v);
            _context.SaveChanges();
        }

        public void DeleteModele(Modele v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v));
            }
            _context.Modeles.Remove(v);
            _context.SaveChanges();
        }

        public IEnumerable<Modele> GetAllModeles()
        {/* RELATION Ajout relation */
            return _context.Modeles.Include("LaMarque").ToList();
        }

        public Modele GetModeleById(int id)
        {/* RELATION Ajout relation */
            return _context.Modeles.Include("LaMarque").FirstOrDefault(v => v.IdModele == id)!;
        }

        public void UpdateModele(Modele v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v));
            }
            _context.SaveChanges();
        }
    }
}
