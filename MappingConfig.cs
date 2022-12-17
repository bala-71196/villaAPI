using AutoMapper;
using villaAPI.Model;
using villaAPI.Model.DTO;

namespace villaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<villa, villaDTO>().ReverseMap();
            CreateMap<VillaCreateDTO,villa>().ReverseMap();
            CreateMap<VillaUpdateDTO,villa>().ReverseMap();

        }
    }
}
