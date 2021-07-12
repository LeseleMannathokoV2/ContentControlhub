using AutoMapper;
using WebApI_Project.Data.Dto;
using WebApI_Project.Data.Entities;

namespace WebApI_Project.Helpers
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Content, ContentDto>();
        }
    }
}
