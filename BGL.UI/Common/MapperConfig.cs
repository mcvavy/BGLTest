using AutoMapper;
using BGL.Core.Entities;
using BGL.UI.Models.DTO;

namespace BGL.UI.Common
{
    public static class MapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RootObject, RepoDto>().ReverseMap();
                cfg.CreateMap<Owner, PersonDto>().ReverseMap();
            });
        }
    }
}