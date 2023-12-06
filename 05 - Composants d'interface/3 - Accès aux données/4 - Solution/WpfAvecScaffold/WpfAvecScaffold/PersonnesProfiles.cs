
using AutoMapper;

namespace WpfAvecScaffold.Models
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
