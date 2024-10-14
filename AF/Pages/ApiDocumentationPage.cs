using AF.BaseEntities;
using AF.Utils.Wrappers;
using OpenQA.Selenium;

namespace AF.Pages;

public class ApiDocumentationPage(IWebDriver driver, bool evaluateStatus = false, bool openPageByUrl = false)
    : BasePage(driver, evaluateStatus, openPageByUrl)
{
    private const string Endpoint = "/ui/#api";
    private readonly By _apiDocumentationTitleLocator = By.XPath("//h1[text()='API Documentation']");
    public Title ApiDocumentationTitle => new(Driver, _apiDocumentationTitleLocator);

    protected override bool EvaluateLoadedStatus()
    {
        try
        {
            return ApiDocumentationTitle is { IsDisplayed: true, Text: "API Documentation" };
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