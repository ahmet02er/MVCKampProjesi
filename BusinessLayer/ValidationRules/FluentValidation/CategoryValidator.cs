using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Olamaz...");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklaması Boş Olamaz...");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adı En Az ( 3 ) Karakter Olması Gerekiyor...");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori Adı ( 20 ) Karakterden Fazla Olamaz...");
        }
    }
}
