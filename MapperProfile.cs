using AutoMapper;
using Data;
using Data.Models;

namespace Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {
            CreateMap<User, RegisterModel>();
            CreateMap<RegisterModel, User>()


                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
    .            ForMember(dest => dest.TcNO, opt => opt.Ignore());


        }
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<User, UserDto>()
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            }
            public class PhotoMappingProfile : Profile
            {
                public PhotoMappingProfile()
                {
                    CreateMap<Photo, PhotoDto>();
                }
            }

        }


    }
        
    
}
