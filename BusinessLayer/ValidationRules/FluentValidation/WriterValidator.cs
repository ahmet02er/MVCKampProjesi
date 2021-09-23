using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanı Boş Olamaz...");
            RuleFor(x => x.WriterLastName).NotEmpty().WithMessage("Yazar Adı Boş Olamaz...");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı Boş Olamaz...");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Bilgisi Boş Olamaz...");
            RuleFor(x => x.WriterAbout).Must(IsAboutValid).WithMessage("Yazar Hakkındaki Bilgilerde 'a' Harfi Kullanılması Zorunludur...");
            RuleFor(x => x.WriterLastName).MinimumLength(3).WithMessage("Yazar Adı En Az ( 3 ) Karakter Olması Gerekiyor...");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Yazar Soyadı En Az ( 3 ) Karakter Olması Gerekiyor...");
            RuleFor(x => x.WriterLastName).MaximumLength(20).WithMessage("Yazar Adı ( 30 ) Karakterden Fazla Olamaz...");
        }
        private bool IsAboutValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[a,A])");
                return regex.IsMatch(arg);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
