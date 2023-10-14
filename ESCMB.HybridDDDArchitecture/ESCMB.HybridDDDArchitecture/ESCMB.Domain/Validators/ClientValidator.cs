using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Validators;
using ESCMB.Domain.Entities;
using FluentValidation;


namespace ESCMB.Domain.Validators
{
    public class ClientValidator : EntityValidator<Client>
    {
        public ClientValidator() 
        {
            RuleFor(x => x.Nombre).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            RuleFor(x => x.Apellido).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            RuleFor(x => x.DNI).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            
        }
    }
}
