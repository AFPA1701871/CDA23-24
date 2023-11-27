using API_Personnes.Models.Data;
using API_Personnes.Models.DTO;
using AutoMapper;

namespace API_Personnes.Models.Profiles
{
    public class PersonnesProfiles :Profile
    {
        public PersonnesProfiles()
        {
            CreateMap<Personne, PersonnesDTO>();
            CreateMap<PersonnesDTO, Personne>();
        }
    }
}
