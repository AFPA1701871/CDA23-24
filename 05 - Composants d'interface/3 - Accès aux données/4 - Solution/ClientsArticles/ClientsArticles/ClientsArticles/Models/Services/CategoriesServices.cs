using ClientsArticles.Models;
using ClientsArticles.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientsArticles.Models.Services
{
    public class CategoriesServices
    {

        private readonly ClientsArticlesDbContext _context;

        public CategoriesServices(ClientsArticlesDbContext context)
        {
            _context = context;
        }

        public void AddCategorie(Categorie categ)
        {
            if (categ == null)
            {
                throw new ArgumentNullException(nameof(categ));
            }
            _context.Categories.Add(categ);
            _context.SaveChanges();
        }

        public void DeleteCategorie(Categorie categ)
        {
            if (categ == null)
            {
                throw new ArgumentNullException(nameof(categ));
            }
            _context.Categories.Remove(categ);
            _context.SaveChanges();
        }

        public IEnumerable<Categorie> GetAllCategories()
        {
            return _context.Categories.Include("ListeArticles").ToList();
        }

        public Categorie GetCategorieById(int id)
        {
            return _context.Categories.Include("ListeArticles").FirstOrDefault(categ => categ.IdCategorie == id);
        }

        public void UpdateCategorie(Categorie categ)
        {
            if (categ == null)
            {
                throw new ArgumentNullException(nameof(categ));
            }
            _context.SaveChanges();
        }
    }
}
