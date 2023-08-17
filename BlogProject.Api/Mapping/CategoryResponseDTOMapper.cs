using AutoMapper;
using BlogProject.Entity.DTO.Category;
using BlogProject.Entity.Poco;

namespace BlogProject.Api.Mapping
{
    public class CategoryResponseDTOMapper :Profile
    {

        public CategoryResponseDTOMapper()
        {
            CreateMap<Category, CategoryResponseDTO>()
               .ForMember(dest => dest.Name, opt =>
               {
                   opt.MapFrom(src => src.Name);

               })
               .ForMember(dest => dest.Active, opt =>
               {
                   opt.MapFrom(src => src.IsActive);

               })
               .ForMember(dest => dest.Delete, opt =>
               {
                   opt.MapFrom(src => src.IsDelete);

               }).ReverseMap();
        }

        
    }

}


