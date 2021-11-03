using FluentValidation;
using PrivatBankTestApi.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Validators
{
    public class RequestsMessageValidator : AbstractValidator<RequestsMessage>
    {
        public RequestsMessageValidator()
        {
            RuleFor(rs => rs.ClientId).NotEmpty().WithMessage("ClientId is empty.");
            RuleFor(rs => rs.DepartmentAddress).NotEmpty().WithMessage("DepartmentAddress is empty.");
        }
    }
}
