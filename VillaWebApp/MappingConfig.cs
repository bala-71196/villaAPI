using AutoMapper;
using VillaWebApp.Model;
using VillaWebApp.Model.DTO;

namespace VillaWebApp
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            //VillaAPI
            CreateMap<VillaCreateDTO, villaDTO>().ReverseMap();
            CreateMap<VillaUpdateDTO, villaDTO>().ReverseMap();

            //VillaNumberAPI
            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();

        }
    }
}
