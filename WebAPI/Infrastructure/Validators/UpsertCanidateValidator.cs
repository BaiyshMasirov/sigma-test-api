using FluentValidation;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Validators
{
    public class UpsertCanidateValidator : AbstractValidator<UpsertCandidateRequest>
    {
        public UpsertCanidateValidator()
        {
            RuleFor(x => x.FirstName)
             .NotEmpty().WithMessage("Field is required");

            RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Field is required");

            RuleFor(x => x.Email)
            .NotEmpty().EmailAddress().WithMessage("Field is required");

            RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Field is required");

            RuleFor(x => x.CallStartDate)
            .NotEmpty().WithMessage("Field is required")
             .When(x => x.IsNeedCall);

            RuleFor(x => x.CallStartDate)
            .NotEmpty().WithMessage("Field is required")
             .When(x => x.IsNeedCall);
        }
    }
}