using System.Net;
using AF.BaseEntities;
using AF.Models;
using AF.Utils;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace AF.Tests.Api;

[TestFixture]
[AllureParentSuite("Login")]
[Category("API")]
[Category("Login")]
[Category("Smoke")]
[AllureSeverity(SeverityLevel.critical)]
public class ApiLoginTests : BaseApiTest
{
    [Test]
    [AllureDescription("Authenticate user though API")]
    [Category("Positive")]
    public void LoginApi_AuthenticateUser_UnauthorizedStatusCodeReturns()
    {
        var user = new UserModel.UserBuilder()
            .WithEmail(Configurator.ReadConfiguration().Email)
            .WithPassword(Configurator.ReadConfiguration().Password)
            .Build();

        var token = LoginSteps.AuthenticateUser(user);

        Assert.Multiple(() =>
        {
            Assert.That(string.IsNullOrEmpty(token), Is.False);
            Assert.That(token, Does.StartWith("Bearer "));
        });
    }

    [Test]
    [AllureDescription("Authenticate user with invalid credentials though API")]
    [Category("Negative")]
    public void LoginApi_AuthenticateUserWithInvalidCredentials_UnauthorizedStatusCodeReturns()
    {
        var user = new UserModel.UserBuilder()
            .WithEmail("test")
            .WithPassword("test")
            .Build();

        var response = LoginSteps.AuthenticateUserWithInvalidData(user);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [Test]
    [AllureDescription("Authenticate user without email though API")]
    [Category("Negative")]
    public void LoginAi_AuthenticateUserWithoutUsername_UnauthorizedStatusCodeReturns()
    {
        var user = new UserModel.UserBuilder()
            .WithPassword(Configurator.ReadConfiguration().Password)
            .Build();

        var response = LoginSteps.AuthenticateUserWithInvalidData(user);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    [AllureDescription("Authenticate user without password though API")]
    [Category("Negative")]
    public void LoginApi_AuthenticateUserWithoutPasswordTest_UnauthorizedStatusCodeReturns()
    {
        var user = new UserModel.UserBuilder()
            .WithEmail(Configurator.ReadConfiguration().Email)
            .Build();

        var response = LoginSteps.AuthenticateUserWithInvalidData(user);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}