using AutoMapper;
using BlogProject.Entity.DTO.Article;
using BlogProject.Entity.Poco;

namespace BlogProject.Api.Mapping
{
    public class ArticleRequestDTOMapper : Profile
    {

        public ArticleRequestDTOMapper()
        {
            CreateMap<Article, ArticleRequestDTO>()
               .ForMember(dest => dest.Guid, opt =>
               {
                   opt.MapFrom(src => src.Guid);

               })
               .ForMember(dest => dest.Title, opt =>
               {
                   opt.MapFrom(src => src.Title);

               })
               .ForMember(dest => dest.Content, opt =>
               {
                   opt.MapFrom(src => src.Content);

               })
               .ForMember(dest => dest.CategoryGuid, opt =>
               {
                   opt.MapFrom(src => src.Category.Guid);

               })
               .ForMember(dest => dest.UserGuid, opt =>
               {
                   opt.MapFrom(src => src.User.Guid);

               }).ReverseMap();
        }



    }
}
    