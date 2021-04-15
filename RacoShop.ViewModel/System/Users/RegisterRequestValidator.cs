using FluentValidation;
using System;

namespace RacoShop.ViewModel.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required")
                    .MaximumLength(200).WithMessage("FirstName can not over 200 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required")
                    .MaximumLength(200).WithMessage("LastName can not over 200 characters");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday can not getter than 100 years");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                    .Matches("/^.+@.+$/").WithMessage("Email format not match");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone is required");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                    .MinimumLength(6).WithMessage("Password is at least 6 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                    context.AddFailure("Confirm password is not match");
            });
        }
    }
}
