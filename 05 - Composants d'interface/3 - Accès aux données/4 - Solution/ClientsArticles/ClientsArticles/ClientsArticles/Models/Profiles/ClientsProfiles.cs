using AutoMapper;
using ClientsArticles.Models.Data;
using ClientsArticles.Models.DTOs;

namespace ClientsArticles.Models.Profiles
{
    public class ClientsProfiles:Profile
    {
        public ClientsProfiles()
        {
            CreateMap<ClientsDtoIN, Client>();
            CreateMap<Client, ClientsDtoOUT>();
            CreateMap<Client, ClientsDtoAvecCommandes>();
        }
    }
}
