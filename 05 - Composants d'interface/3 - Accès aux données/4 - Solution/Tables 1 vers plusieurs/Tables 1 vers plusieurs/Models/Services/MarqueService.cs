using Microsoft.EntityFrameworkCore;
using Tables_1_vers_plusieurs.Models.Data;

namespace Tables_1_vers_plusieurs.Models.Services
{
    public class MarqueService
    {
        
        private readonly VoitureContext _context;

        public MarqueService(VoitureContext context)
        {
            _context = context;
        }

        public void AddMarque(Marque v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v));
            }
            _context.Marques.Add(v);
            _context.SaveChanges();
        }

        public void DeleteMarque(Marque v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v));
            }
            _context.Marques.Remove(v);
            _context.SaveChanges();
        }

        public IEnumerable<Marque> GetAllMarques()
        {/* RELATION Ajout relation */
            return _context.Marques.Include("ListeModeles").ToList();
        }

        public Marque GetMarqueById(int id)
        {/* RELATION Ajout relation */
            return _context.Marques.Include("ListeModeles").FirstOrDefault(v => v.IdMarque == id)!;
        }

        public void UpdateMarque(Marque v)
        {
            if (v == null)
            {
                throw new ArgumentNullException(nameof(v));
            }
            _context.SaveChanges();
        }
    }
}
