using AutoMapper;
using ClientsArticles.Models.Data;
using ClientsArticles.Models.DTOs;

namespace ClientsArticles.Models.Profiles
{
    public class CategoriesProfiles:Profile
    {
        public CategoriesProfiles() {

            CreateMap<Categorie, CategoriesDtoOUT>();
            CreateMap<CategoriesDtoIN, Categorie>();
            CreateMap<Categorie, CategoriesDtoAvecArticles>();
           
        }
    }
}
