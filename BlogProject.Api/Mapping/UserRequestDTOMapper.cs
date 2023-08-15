using AutoMapper;
using BlogProject.Entity.DTO.User;
using BlogProject.Entity.Poco;

namespace BlogProject.Api.Mapping
{
    public class UserRequestDTOMapper : Profile
    {
        public UserRequestDTOMapper()
        {
            CreateMap<User, UserRequestDTO>()
                .ForMember(dest => dest.Adi, opt =>
                {
                    opt.MapFrom(src => src.FirstName);

                })

                .ForMember(dest => dest.Soyadi, opt =>
                 {
                 opt.MapFrom(src => src.LastName);

                 })

                .ForMember(dest => dest.KullaniciAdi, opt =>
                {
                 opt.MapFrom(src => src.UserName);

                })
                .ForMember(dest => dest.Sifre, opt =>
                {
                 opt.MapFrom(src => src.Password);

                }).ReverseMap();
        }
    }
}
