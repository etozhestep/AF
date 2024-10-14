using AF.BaseEntities;
using AF.Utils.Wrappers;
using OpenQA.Selenium;

namespace AF.Pages;

public class ProfilePage(IWebDriver driver, bool evaluateStatus = false, bool openPageByUrl = false)
    : BasePage(driver, evaluateStatus, openPageByUrl)
{
    private const string Endpoint = "/ui/#userProfile/assignedProjects";
    private readonly By _profileTitleLocator = By.XPath("//span[@title='User profile']");
    public Title ProfileTitle => new(Driver, _profileTitleLocator);

    protected override bool EvaluateLoadedStatus()
    {
        try
        {
            return ProfileTitle is { IsDisplayed: true, Text: "API Documentation" };
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