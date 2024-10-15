using AF.BaseEntities;
using AF.Utils;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace AF.Tests.Ui;

[TestFixture]
[AllureParentSuite("Login")]
[AllureSubSuite("UI")]
[Category("UI")]
[Category("Login")]
[Category("Smoke")]
[AllureSeverity(SeverityLevel.critical)]
public class LoginTests : BaseTest
{
    [SetUp]
    [AllureBefore("Open Login page by URL")]
    public void SetupFixture()
    {
        Logger.Info("Open Login page by URL: {0}", Configurator.ReadConfiguration().Url);
        NavigationSteps.OpenLoginPage();
    }

    [Test]
    [AllureSuite("Login")]
    [Category("ValidCredentials")]
    [Category("Positive")]
    [AllureDescription("Login with valid credentials")]
    [Author("ASciapaniuk")]
    public void Login_ValidCredentials_LaunchesPageOpened()
    {
        Assert.That(UserLoginSteps.LoginWithValidCredentials().PageTitle.IsDisplayed,
            "Page title is not displayed");
    }

    [Test]
    [AllureSuite("Login")]
    [Category("Negative")]
    [Category("ErrorNotification")]
    [AllureDescription("Login with invalid credentials.")]
    [Author("ASciapaniuk")]
    public void Login_InvalidCredentials_ErrorNotificationAppeared()
    {
        const string expectedErrorMessage = "An error occurred while connecting to server: " +
                                            "You do not have enough permissions. Bad credentials";

        var actualErrorMessage = UserLoginSteps.LoginWithInvalidCredentials();

        Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
    }

    [Test]
    [AllureSuite("Login")]
    [Category("Negative")]
    [Category("ErrorNotification")]
    [AllureDescription("Login with empty email.")]
    [Author("ASciapaniuk")]
    public void Login_EmptyEmail_ErrorNotificationAppeared()
    {
        const string expectedEmailErrorMessage = "User name may contain only Latin, numeric characters, " +
                                                 "hyphen, underscore, dot (from 1 to 128 symbols)";

        UserLoginSteps.LoginWithEmptyEmail();

        Assert.Multiple(() =>
            {
                Assert.That(LoginPage.EmailFieldAlert.IsDisplayed, "Email field alert is not displayed");
                Assert.That(LoginPage.EmailFieldAlert.Text, Is.EqualTo(expectedEmailErrorMessage),
                    $"Error message is not correct. Expected: {expectedEmailErrorMessage}");
            }
        );
    }

    [Test]
    [AllureSuite("Login")]
    [Category("Negative")]
    [Category("ErrorNotification")]
    [AllureDescription("Login with empty password.")]
    [Author("ASciapaniuk")]
    public void Login_EmptyPassword_ErrorNotificationAppeared()
    {
        const string expectedPasswordErrorMessage = "Password should contain at least 4 characters; " +
                                                    "a special symbol; upper-case (A - Z); lower-case";

        UserLoginSteps.LoginWithEmptyPassword();

        Assert.Multiple(() =>
            {
                Assert.That(LoginPage.PasswordFieldAlert.Text, Is.EqualTo(expectedPasswordErrorMessage));
                Assert.That(LoginPage.PasswordFieldAlert.IsDisplayed);
            }
        );
    }

    [Test]
    [AllureSuite("Login")]
    [Category("Negative")]
    [Category("ErrorNotification")]
    [AllureDescription("Login with empty credentials.")]
    [Author("ASciapaniuk")]
    public void Login_EmptyCredentials_ErrorNotificationAppeared()
    {
        const string expectedEmailErrorMessage = "User name may contain only Latin, numeric characters, " +
                                                 "hyphen, underscore, dot (from 1 to 128 symbols)";

        const string expectedPasswordErrorMessage = "Password should contain at least 4 characters; " +
                                                    "a special symbol; upper-case (A - Z); lower-case";

        UserLoginSteps.LoginWithEmptyCredentials();

        Assert.Multiple(() =>
            {
                Assert.That(LoginPage.EmailFieldAlert.Text, Is.EqualTo(expectedEmailErrorMessage),
                    $"Error message is not correct. Expected: {expectedEmailErrorMessage}");
                Assert.That(LoginPage.PasswordFieldAlert.Text, Is.EqualTo(expectedPasswordErrorMessage),
                    $"Error message is not correct. Expected: {expectedPasswordErrorMessage}");
            }
        );
    }

    [Test]
    [AllureSuite("LogOut")]
    [Category("Positive")]
    [AllureDescription("Log out from header popup. Expected OKTA page with URL: https://coxauto.okta.com opened.")]
    [Author("ASciapaniuk")]
    public void Login_LogoutFromUserPopup_LoginPageOpened()
    {
        const string expectedEndpoint = "login";

        UserLoginSteps.LoginWithValidCredentials();
        UserLoginSteps.SignOut();

        Assert.Multiple(() =>
        {
            Assert.That(CommonSteps.GetCurrentUrl(), Does.Contain(expectedEndpoint),
                "New URL is not correct");
            Assert.That(LoginPage.EmailField.IsDisplayed,
                "Email field is not displayed");
        });
    }
}