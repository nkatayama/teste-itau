using ApiItau.Domain;

namespace ApiItau.Business.Validations
{
    public class PasswordCommandValidation : PasswordValidator
    {
        public PasswordCommandValidation()
        {
            Validate();
        }
    }
}