using System.Linq;
using ApiItau.Business.Validations;
using Xunit;

namespace ApiItau.Tests.BusinessTests
{
    public class LoginValidationUnitTest
    {
        [Theory]
        [InlineData("aB9!", false, "Password must be at least 9 characters long")]
        [InlineData("abcdefghijK!", false, "Password must contain at least one number")]
        [InlineData("abcdefghij9!", false, "Password must contain at least one uppercase letter")]
        [InlineData("ABCDEFGHIJ9!", false, "Password must contain at least one lowercase letter")]
        [InlineData("abcdefghij9K", false, "Password must contain at least one special character")]
        [InlineData("abcdefg hij9K!", false, "Password must not contain white spaces")]
        [InlineData("aabcdefghij9K!", false, "Password must not contain repeated characters")]
        [InlineData("abcdefghij9K!", true,"")]
        public void LoginValidationTest(string password, bool isValid, string message)
        {
            var passwordCommandValidation = new PasswordCommandValidation();

            var resultado = passwordCommandValidation.Validate(password);
            
            Assert.Equal(resultado.IsValid, isValid);

            if (!isValid)
            {
                Assert.Contains(message, resultado.Errors.Select(e => e.ErrorMessage));
            }
            else
            {
                Assert.Empty(resultado.Errors);
            }
        }
    }
}
