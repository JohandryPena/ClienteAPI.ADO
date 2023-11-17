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
    public class LoginValidation: AbstractValidator<Cliente>
    {
       
        public LoginValidation() 
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Persona.Identificacion).NotNull();
            RuleFor(x => x.Contraseña).Length(0, 10);

        }
        public ValidationResult LoginValidationResult(Cliente cliente)
        {
            return Validate(cliente);
        }
    }
}
