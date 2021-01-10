using FluentAssertions;
using System.Net; 
using System.Threading.Tasks;
using ApiItau.Web.Tests.Fixtures;
using Xunit;

namespace ApiItau.Web.Tests.Scenarios
{
    public class ValuesTest
    {
        private readonly TestContext _testContext;
        public ValuesTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Login_Get_ReturnsOkResponse_valid()
        {
            _testContext.Client.DefaultRequestHeaders.Add("password", "Abcdefgh9!");
            var response = await _testContext.Client.GetAsync("/api/login/password-check");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ReadAsStringAsync().Result.Should().Be("{\"isValid\":true}");
        }

        [Fact]
        public async Task Login_Get_ReturnsOkResponse_notvalid()
        {
            _testContext.Client.DefaultRequestHeaders.Add("password", "abcde");
            var response = await _testContext.Client.GetAsync("/api/login/password-check");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ReadAsStringAsync().Result.Should().Be("{\"isValid\":false}");
        }

        [Fact]
        public async Task Login_Get_ReturnsOkResponse_notvalid_null()
        {
            var response = await _testContext.Client.GetAsync("/api/login/password-check");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ReadAsStringAsync().Result.Should().Be("{\"isValid\":false}");
        }
    }
}

