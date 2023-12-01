using ClientsArticles.Models;
using ClientsArticles.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientsArticles.Models.Services
{
    public class CommandesServices
    {

        private readonly ClientsArticlesDbContext _context;

        public CommandesServices(ClientsArticlesDbContext context)
        {
            _context = context;
        }

        public void Add(Commande cde)
        {
            if (cde == null)
            {
                throw new ArgumentNullException(nameof(cde));
            }
            _context.Commandes.Add(cde);
            _context.SaveChanges();
        }

        public void Delete(Commande cde)
        {
            if (cde == null)
            {
                throw new ArgumentNullException(nameof(cde));
            }
            _context.Commandes.Remove(cde);
            _context.SaveChanges();
        }

        public IEnumerable<Commande> GetAlls()
        {
            return _context.Commandes.Include("LeClient").Include("LArticle").ToList();
        }

        public Commande GetById(int id)
        {
            return _context.Commandes.Include("LeClient").Include("LArticle").FirstOrDefault(v => v.IdCommande == id);
        }

        public void Update(Commande cde)
        {
            if (cde == null)
            {
                throw new ArgumentNullException(nameof(cde));
            }
            _context.SaveChanges();
        }
    }
}
