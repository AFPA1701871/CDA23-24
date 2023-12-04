using ClientsArticles.Models;
using ClientsArticles.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientsArticles.Models.Services
{
    public class ClientsServices
    {

        private readonly ClientsArticlesDbContext _context;

        public ClientsServices(ClientsArticlesDbContext context)
        {
            _context = context;
        }

        public void AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void DeleteClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.Include("ListeCommandes.LArticle").ToList();
        }

        public Client GetClientById(int id)
        {
            return _context.Clients.Include("ListeCommandes.LArticle").FirstOrDefault(client => client.IdClient == id);
        }

        public void UpdateClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            _context.SaveChanges();
        }
    }
}