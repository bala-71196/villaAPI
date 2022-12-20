using AutoMapper;
using villaAPI.Model;
using villaAPI.Model.DTO;

namespace villaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            //VillaAPI
            CreateMap<villa, villaDTO>().ReverseMap();
            CreateMap<VillaCreateDTO,villa>().ReverseMap();
            CreateMap<VillaNumberUpdateDTO,villa>().ReverseMap();

            //VillaNumberAPI
            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber,VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber,VillaNumberUpdateDTO>().ReverseMap();

        }
    }
}
