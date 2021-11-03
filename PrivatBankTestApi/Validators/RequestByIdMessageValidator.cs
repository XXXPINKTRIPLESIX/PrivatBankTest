using FluentValidation;
using PrivatBankTestApi.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivatBankTestApi.Validators
{
    public class RequestByIdMessageValidator : AbstractValidator<RequestByIdMessage>
    {
        public RequestByIdMessageValidator()
        {
            RuleFor(rs => rs.RequestId).NotNull().WithMessage("RequestId is null.");
        }
    }
}
