using BlogProject.Entity.DTO.Category;
using FluentValidation;

namespace BlogProject.Api.Validation.FluentValidation
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDTO>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş Olamaz");
            
        }
    }
}
