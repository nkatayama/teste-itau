using FluentValidation;
using System.Linq;
using System.Text.RegularExpressions;

namespace ApiItau.Business.Validations
{
    public abstract class PasswordValidator : AbstractValidator<string>
    {
        protected void Validate()
        {
            RuleFor(s => s)
                .MinimumLength(9).WithMessage("Password must be at least 9 characters long")
                .Must(VerifyAtLeastOneNumber).WithMessage("Password must contain at least one number")
                .Must(VerifyAtLeastOneUpperCase).WithMessage("Password must contain at least one uppercase letter")
                .Must(VerifyAtLeastOneLowerCase).WithMessage("Password must contain at least one lowercase letter")
                .Must(VerifyAtLeastOneSpecialCharacter).WithMessage("Password must contain at least one special character")
                .Must(VerifyWhiteSpaces).WithMessage("Password must not contain white spaces")
                .Must(VerifyRepeatedCharacters).WithMessage("Password must not contain repeated characters")
                ;
        }

        protected static bool VerifyAtLeastOneNumber(string senha)
        {
            return senha.Where(s => char.IsNumber(s)).Count() > 0;
        }

        protected static bool VerifyAtLeastOneUpperCase(string senha)
        {
            return senha.Where(s => char.IsUpper(s)).Count() > 0;
        }

        protected static bool VerifyAtLeastOneLowerCase(string senha)
        {
            return senha.Where(s => char.IsLower(s)).Count() > 0;
        }

        protected static bool VerifyAtLeastOneSpecialCharacter(string senha)
        {
            return Regex.IsMatch(senha, (@"[!@#$%^&*()-+]"));
        }

        protected static bool VerifyWhiteSpaces(string senha)
        {
            return !senha.Contains(" ");
        }

        protected static bool VerifyRepeatedCharacters(string senha)
        {
            return !senha.GroupBy(s => s).Where(c => c.Count() > 1).Any();
        }
    } 
}