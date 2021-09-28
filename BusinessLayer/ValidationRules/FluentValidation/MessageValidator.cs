using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
   public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageReceiverMail).NotEmpty().WithMessage("Alıcı E-Posta Adresi Boş Olamaz...");
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konu Boş Olamaz...");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş Olamaz...");
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("Konu En Az ( 3 ) Karakter Olması Gerekiyor...");
            RuleFor(x => x.MessageSubject).MaximumLength(50).WithMessage("Konu En Fazla ( 50 ) Karakterden Fazla Olamaz...");
        }
    }
}
