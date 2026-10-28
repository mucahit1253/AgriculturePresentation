using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Görsel başlığı boş geçilemez.");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Görsel açıklaması boş geçilemez.");
            RuleFor(p => p.ImageUrl).NotEmpty().WithMessage("Görsel URL'li  boş geçilemez.");
            RuleFor(p => p.Title).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız.");
            RuleFor(p => p.Title).MinimumLength(8).WithMessage("Lütfen en az 8 karakter veri girişi yapınız.");
            RuleFor(p => p.Description).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter veri girişi yapınız.");
            RuleFor(p => p.Description).MinimumLength(20).WithMessage("Lütfen en az 20 karakter veri girişi yapınız.");


        }
    }
}
