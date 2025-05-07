using FluentValidation;
using uMarket.Models;

namespace uMarket.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(2, 20).WithMessage("Username must be between 2 and 20 characters.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .Matches(@"@").WithMessage("Email must contain '@' character.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"\d").WithMessage("Password must contain at least one digit.")
                .Matches(@"[!@#$%^&*(),.?:{}|<>]").WithMessage("Password must contain at least one special character.");

            RuleFor(u => u.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[0-9]{7,15}$").WithMessage("Phone number must be valid.");

            RuleFor(u => u.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(100).WithMessage("Address must be 100 characters or fewer.");
        }
    }
}
