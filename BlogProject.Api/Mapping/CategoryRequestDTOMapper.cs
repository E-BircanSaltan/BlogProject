using AutoMapper;
using BlogProject.Entity.DTO.Category;
using BlogProject.Entity.Poco;

namespace BlogProject.Api.Mapping
{
    public class CategoryRequestDTOMapper :Profile
    {
        public CategoryRequestDTOMapper()
        {
            CreateMap<Category, CategoryRequestDTO>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.MapFrom(src => src.Name);

                }).ReverseMap();
        }
    }
}
