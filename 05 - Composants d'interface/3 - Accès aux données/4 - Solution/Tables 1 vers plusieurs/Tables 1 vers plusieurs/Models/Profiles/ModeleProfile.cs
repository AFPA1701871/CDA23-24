using AutoMapper;
using Tables_1_vers_plusieurs.Models.Data;
using Tables_1_vers_plusieurs.Models.Dtos;

namespace Tables_1_vers_plusieurs.Models.Profiles
{
    public class ModeleProfile : Profile
    {
        public ModeleProfile()
        {
            CreateMap<Modele, ModeleDtoSansMarque>();
            CreateMap<ModeleDtoSansMarque, Modele>();
            CreateMap<ModeleDtoAvecMarque, Modele>().ForMember(q=>q.LaMarque,a=>a.MapFrom(m=>m.MarqueId));    /* RELATION On donne l'info sur comment retrouver les données manquantes */
            CreateMap<Modele, ModeleDtoAvecMarque>();
        }
    }
}
