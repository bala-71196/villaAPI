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
            CreateMap<VillaUpdateDTO,villa>().ReverseMap();

            //VillaNumberAPI
            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber,VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber,VillaNumberUpdateDTO>().ReverseMap();

            CreateMap<ApplicationUser,UserDTO>().ReverseMap();

        }
    }
}
