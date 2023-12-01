using ClientsArticles.Models;
using ClientsArticles.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientsArticles.Models.Services
{
    public class ArticlesServices
    {
        private readonly ClientsArticlesDbContext _context;

        public ArticlesServices(ClientsArticlesDbContext context)
        {
            _context = context;
        }

        public void AddArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void DeleteArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles.Include("ListeCommandes.LeClient").ToList();
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.Include("ListeCommandes.LeClient").FirstOrDefault(article => article.IdArticle == id);
        }

        public void UpdateArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            _context.SaveChanges();
        }
    }
}
