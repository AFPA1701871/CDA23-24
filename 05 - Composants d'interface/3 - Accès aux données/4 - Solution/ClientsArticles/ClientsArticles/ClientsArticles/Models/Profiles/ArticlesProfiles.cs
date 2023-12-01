using AutoMapper;
using ClientsArticles.Models.Data;
using ClientsArticles.Models.DTOs;

namespace ClientsArticles.Models.Profiles
{
    public class ArticlesProfiles:Profile
    {
        public ArticlesProfiles()
        {
            CreateMap<ArticlesDtoIN, Article>();
            CreateMap<Article, ArticlesDtoOUT>();
            CreateMap<Article, ArticlesDtoAvecCategorie>();
            CreateMap<Article, ArticlesDtoAvecCategorieEtCommandes>();
            CreateMap<Article, ArticlesDtoAvecCommandes>();
        }
    }
}
