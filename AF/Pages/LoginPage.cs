using AF.BaseEntities;
using AF.Utils.Wrappers;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace AF.Pages;

public class LoginPage(IWebDriver driver, bool evaluateStatus = false, bool openPageByUrl = false)
    : BasePage(driver, evaluateStatus, openPageByUrl)
{
    private static readonly string Endpoint = string.Empty;
    private readonly By _emailFieldXpath = By.XPath("//input[@placeholder='Login']");
    private readonly By _errorNotificationXpath = By.XPath("//*[contains(text(),'Bad credentials')]");
    private readonly By _fieldAlertXpath = By.XPath("/following::span[contains(@class,'error')]");
    private readonly By _passwordFieldXpath = By.XPath("//input[@placeholder='Password']");
    private readonly By _signInButtonXpath = By.XPath("//button[@type='submit']");

    public Field EmailField => new(Driver, _emailFieldXpath);
    public Field PasswordField => new(Driver, _passwordFieldXpath);
    public Button SignInButton => new(Driver, _signInButtonXpath);
    public Notification Notification => new(Driver, _errorNotificationXpath);

    public FieldAlert EmailFieldAlert =>
        new(Driver, By.XPath(_emailFieldXpath.Criteria + _fieldAlertXpath.Criteria));

    public FieldAlert PasswordFieldAlert =>
        new(Driver, By.XPath(_passwordFieldXpath.Criteria + _fieldAlertXpath.Criteria));

    [AllureStep("Evaluating the loaded status of the Login page")]
    protected override bool EvaluateLoadedStatus()
    {
        try
        {
            return EmailField.IsDisplayed && PasswordField.IsDisplayed && SignInButton.IsDisplayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    protected override string GetEndpoint()
    {
        return Endpoint;
    }
}