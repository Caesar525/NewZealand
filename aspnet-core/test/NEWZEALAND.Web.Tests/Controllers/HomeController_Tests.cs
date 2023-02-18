using System.Threading.Tasks;
using NEWZEALAND.Models.TokenAuth;
using NEWZEALAND.Web.Controllers;
using Shouldly;
using Xunit;

namespace NEWZEALAND.Web.Tests.Controllers
{
    public class HomeController_Tests: NEWZEALANDWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}