using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using CouponBook.Dtos;
using CouponBook.Validators;

namespace CouponBook.Validators
{
    public class CustomerUserSignupValidator : AbstractValidator<CustomerUserSignupDto>
    {
      public CustomerUserSignupValidator()
      {
        RuleFor(x => x.Name)
          .NotEmpty().WithMessage("El nombre es obligatorio.")
          .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
            .EmailAddress().WithMessage("Formato de correo electrónico no válido.")
            .Must(ValidationRules.NoSpaces).WithMessage("El correo electrónico no puede contener espacios.");

        RuleFor(x => x.DateBirth)
          .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.")
          .Must(ValidationRules.BeAValidDate).WithMessage("Fecha de nacimiento no válida.")
          .Must(ValidationRules.BeAtLeast18YearsOld).WithMessage("Debes tener al menos 18 años.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("La contraseña es obligatoria.")
            .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.")
            .Matches("[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
            .Matches("[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
            .Matches("[0-9]").WithMessage("La contraseña debe contener al menos un número.")
            .Matches("[^a-zA-Z0-9]").WithMessage("La contraseña debe contener al menos un carácter especial.");
      }
        
    }

}
