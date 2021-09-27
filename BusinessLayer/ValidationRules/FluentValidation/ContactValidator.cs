using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("E-Posta Adresi Boş Olamaz...");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz...");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adında En Az ( 3 ) Karakter Olması Gerekiyor...");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Olamaz...");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu En Az ( 3 ) Karakter Olması Gerekiyor...");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu En Fazla ( 50 ) Karakterden Fazla Olamaz...");
        }
    }
}
