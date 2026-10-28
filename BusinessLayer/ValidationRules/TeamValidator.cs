using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(p => p.PersonName).NotEmpty().WithMessage("Takım arkadaşı ismini boş geçemezsiniz.");
            RuleFor(p => p.Title).NotEmpty().WithMessage("Görev kısmını  boş geçemezsiniz.");
            RuleFor(p => p.ImageUrl).NotEmpty().WithMessage("Görse URL boş geçemezsiniz.");
            RuleFor(p => p.PersonName).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız.");
            RuleFor(p => p.PersonName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız.");
            RuleFor(p => p.Title).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız.");
            RuleFor(p => p.Title).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.");



        }
    }
}
