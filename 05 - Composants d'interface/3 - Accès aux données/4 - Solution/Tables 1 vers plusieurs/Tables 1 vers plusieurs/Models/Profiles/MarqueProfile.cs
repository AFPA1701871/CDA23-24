using AutoMapper;
using Tables_1_vers_plusieurs.Models.Data;
using Tables_1_vers_plusieurs.Models.Dtos;

namespace Tables_1_vers_plusieurs.Models.Profiles
{
    public class MarqueProfile : Profile
    {
        public MarqueProfile()
        {

            CreateMap<Marque, MarqueDtoSansModeles>();
            CreateMap<MarqueDtoSansModeles, Marque>();
            CreateMap<MarqueDtoAvecModeles, Marque>().ForMember(m=>m.ListeModeles,a=>a.MapFrom(q=>q.IdMarque)); /* RELATION On donne l'info sur comment retrouver les données manquantes */
            CreateMap<Marque, MarqueDtoAvecModeles>();
                
        }
    }
}
