using API_Personnes2.Models.Data;
using API_Personnes2.Models.DTOs;
using AutoMapper;

namespace API_Personnes2.Models.Profiles
{
    public class PersonnesProfiles : Profile
    {
        public PersonnesProfiles()
        {
            CreateMap<Personne, PersonnesDto>();
            CreateMap<PersonnesDto, Personne>();
        }
    }
}
