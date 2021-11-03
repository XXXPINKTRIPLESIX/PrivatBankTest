using FluentValidation;
using PrivatBankTestApi.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Validators
{
    public class RequestValidator : AbstractValidator<RequestMessage>
    {
        public RequestValidator()
        {
            RuleFor(r => r.ClientId).NotEmpty().WithMessage("ClientId is empty.");
            RuleFor(r => r.DepartmentAddress).NotEmpty().WithMessage("DepartmentAddress is empty.");
            RuleFor(r => r.Currency).NotEmpty().WithMessage("Currency is empty.");
            RuleFor(r => r.Amount).GreaterThan(0).WithMessage("Amount is less or equals null.");
        }
    }
}
