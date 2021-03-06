using ApiItau.Business.Interfaces;
using ApiItau.Business.Validations;
using FluentValidation.Results;

namespace ApiItau.Business.Services
{
    public class PasswordService : IPasswordService
    {
        public ValidationResult ValidatePassword(string senha) 
            => new PasswordCommandValidation().Validate(senha);
    }
}
