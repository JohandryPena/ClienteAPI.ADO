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

            RuleFor(X => X.Persona.Nombre).NotEmpty().NotNull();
            RuleFor(X => X.Persona.Edad).NotNull().NotEmpty().InclusiveBetween(18, 120);
            RuleFor(X => X.Persona.Direccion).NotEmpty().NotNull();
            RuleFor(X => X.Persona.TipoIdentificacion).NotEmpty().NotNull().InclusiveBetween(1,3);
            RuleFor(X => X.Persona.Genero).Matches( @"^[MF]|Otro$");
            RuleFor(x => x.Persona.Identificacion).NotNull().NotEmpty();
            RuleFor(x => x.Persona.Telefono).NotEmpty().NotNull().Matches(@"^3\d{9}$");
            RuleFor(x => x.Contraseña)
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*(),.?"":{}|<>])(?=.*\d)[A-Za-z\d!@#$%^&*(),.?"":{}|<>]{8,}$")
                .NotEmpty().NotNull();

        }
        public ValidationResult ClienteValidationResult(Cliente cliente)
        {
            return Validate(cliente);
        }
    }
}
