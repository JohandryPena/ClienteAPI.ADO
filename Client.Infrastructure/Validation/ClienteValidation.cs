using Client.Domain;
using Client.Domain.DTOs;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.Validation
{
    public class ClienteValidation: AbstractValidator<Cliente>
    {
        public ClienteValidation() 
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(X => X.Persona.Nombre)
       .NotEmpty().WithMessage("El nombre no puede estar vacío.")
       .NotNull().WithMessage("El nombre no puede ser nulo.");

            RuleFor(X => X.Persona.Edad)
                .NotNull().WithMessage("La edad no puede ser nula.")
                .NotEmpty().WithMessage("La edad no puede estar vacía.")
                .InclusiveBetween(18, 120).WithMessage("La edad debe estar entre 18 y 120 años.");

            RuleFor(X => X.Persona.Direccion)
                .NotEmpty().WithMessage("La dirección no puede estar vacía.")
                .NotNull().WithMessage("La dirección no puede ser nula.");

            RuleFor(X => X.Persona.TipoIdentificacion)
                .NotEmpty().WithMessage("El tipo de identificación no puede estar vacío.")
                .NotNull().WithMessage("El tipo de identificación no puede ser nulo.")
                .InclusiveBetween(1, 3).WithMessage("El tipo de identificación debe estar entre 1 y 3.");

            RuleFor(X => X.Persona.Genero)
                .Matches(@"^[MF]|Otro$").WithMessage("El género debe ser 'M', 'F' u 'Otro'.");

            RuleFor(x => x.Persona.Identificacion)
                .NotNull().WithMessage("La identificación no puede ser nula.")
                .NotEmpty().WithMessage("La identificación no puede estar vacía.");

            RuleFor(x => x.Persona.Telefono)
                .NotEmpty().WithMessage("El teléfono no puede estar vacío.")
                .NotNull().WithMessage("El teléfono no puede ser nulo.")
                .Matches(@"^3\d{9}$").WithMessage("El teléfono debe comenzar con '3' y tener un total de 10 dígitos.");

            RuleFor(x => x.Contraseña)
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*(),.?""':{}|<>])(?=.*\d)[A-Za-z\d!@#$%^&*(),.?""':{}|<>]{8,}$").WithMessage("La contraseña debe tener al menos 8 caracteres, incluyendo al menos una mayúscula, una minúscula, un número y un carácter especial.")

                .NotEmpty().WithMessage("La contraseña no puede estar vacía.")
                .NotNull().WithMessage("La contraseña no puede ser nula.");
                

        }
        public ValidationResult ClienteValidationResult(Cliente cliente)
        {
            return Validate(cliente);
        }
    }
}
