using AF.BaseEntities;
using AF.Utils.Wrappers;
using OpenQA.Selenium;

namespace AF.Pages;

public class SettingsPage(IWebDriver driver, bool evaluateStatus = false, bool openPageByUrl = false)
    : BasePage(driver, evaluateStatus, openPageByUrl)
{
    private readonly By _pageTitleXpath = By.XPath("//div[text()='Project Settings']");
    private readonly By _successNotificationXpath = By.XPath("//*[contains(text(),'Signed in successfully')]");
    private const string Endpoint = "/ui/#default_personal/settings/general";

    public Title PageTitle => new(Driver, _pageTitleXpath);

    protected override bool EvaluateLoadedStatus()
    {
        try
        {
            return PageTitle is { IsDisplayed: true, Text: "Project Settings" };
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