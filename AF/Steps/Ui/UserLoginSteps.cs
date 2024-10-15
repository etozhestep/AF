using AF.BaseEntities;
using AF.Pages;
using AF.Utils;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace AF.Steps;

public class UserLoginSteps(IWebDriver driver) : BaseStep(driver)
{
    /// <summary>
    ///     This method handles the login process.
    ///     Firstly open login page by url and then try to enter credentials.
    ///     If the username and password are null, it will log a warning.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    private void Login(string? email, string? password)
    {
        var loginPage = new LoginPage(Driver, true, true);
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            Logger.Warn("Email or password is null");

        if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
        {
            Logger.Warn("Email and password is null or empty");
            loginPage.SignInButton.Click();
        }
        else
        {
            Logger.Info("Entering credentials...");
            loginPage.EmailField.SendText(email);
            loginPage.PasswordField.SendText(password);
            loginPage.SignInButton.Click();
        }
    }

    [AllureStep("Login with valid credentials")]
    public LaunchesPage LoginWithValidCredentials()
    {
        Logger.Info("Logging with valid credentials...");
        var username = Configurator.ReadConfiguration().Email;
        var password = Configurator.ReadConfiguration().Password;
        Login(username, password);
        return new LaunchesPage(Driver, true);
    }

    [AllureStep("Login with invalid credentials")]
    public string LoginWithInvalidCredentials()
    {
        Login("username", "password");
        return LoginPage.Notification.Text;
    }

    [AllureStep("Login with empty username")]
    public string LoginWithEmptyEmail()
    {
        Login("", "password");
        return LoginPage.EmailFieldAlert.Text;
    }

    [AllureStep("Login with empty password")]
    public string LoginWithEmptyPassword()
    {
        Login("username", "");
        return LoginPage.PasswordFieldAlert.Text;
    }

    [AllureStep("Login with empty credentials")]
    public string LoginWithEmptyCredentials()
    {
        Login("", "");
        return LoginPage.Notification.Text;
    }

    [AllureStep("Sign out")]
    public LoginPage SignOut()
    {
        Logger.Info("Signing out...");
        LaunchesPage.SideBar.OpenUserPopup();
        LaunchesPage.UserPopup.LogoutButton.Click();
        return new LoginPage(Driver, true);
    }
}