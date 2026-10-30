using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(p => p.Description1).NotEmpty().WithMessage("Açıklama 1 boş geçilemez");
            RuleFor(p => p.Description2).NotEmpty().WithMessage("Açıklama 2 boş geçilemez");
            RuleFor(p => p.Description3).NotEmpty().WithMessage("Açıklama 3 boş geçilemez");
            RuleFor(p => p.Description4).NotEmpty().WithMessage("Açıklama 4 boş geçilemez");
            RuleFor(p => p.Mapinfo).NotEmpty().WithMessage("Harita bilgisi boş geçilemez");
            RuleFor(p => p.Description1).MaximumLength(40).WithMessage("Açıklama 1 en fazla 40 kareakter giriniz");
            RuleFor(p => p.Description2).MaximumLength(25).WithMessage("Açıklama 2 en fazla 25 kareakter giriniz");
            RuleFor(p => p.Description3).MaximumLength(25).WithMessage("Açıklama 3 en fazla 25 kareakter giriniz");
            RuleFor(p => p.Description4).MaximumLength(25).WithMessage("Açıklama 4 en fazla 25 kareakter giriniz");

        }
    }
}
