using BlogProject.Entity.DTO.User;
using FluentValidation;

namespace BlogProject.Api.Validation.FluentValidation
{
    public class UserRegisterValidation : AbstractValidator<UserRequestDTO>
    {
        public UserRegisterValidation()
        {
            RuleFor(q => q.Adi).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.Soyadi).NotEmpty().WithMessage("Soyadı Boş Olamaz");
            RuleFor(q => q.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");



        }
    }
}
