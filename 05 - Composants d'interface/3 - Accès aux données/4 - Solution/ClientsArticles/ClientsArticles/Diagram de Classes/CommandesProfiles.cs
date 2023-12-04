using AutoMapper;
using ClientsArticles.Models.Data;
using ClientsArticles.Models.DTOs;

namespace ClientsArticles.Models.Profiles
{
    public class CommandesProfiles:Profile
    {
        public CommandesProfiles()
        {
            CreateMap<CommandesDtoIN, Commande>();
            CreateMap<Commande, CommandesDtoOUT>();
            CreateMap<Commande, CommandesDtoAvecArticle>();
            CreateMap<Commande, CommandesDtoAvecClient>();
            CreateMap<Commande, CommandesDtoAvecClientEtArticle>();
        }
    }
}
