using FluentValidation.Results;

namespace ApiItau.Business.Interfaces
{
    public interface IPasswordService
    {
        ValidationResult ValidatePassword(string password);
    }
}
