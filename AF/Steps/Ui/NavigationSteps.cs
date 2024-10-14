using AF.BaseEntities;
using AF.Pages;
using OpenQA.Selenium;

namespace AF.Steps;

public class NavigationSteps(IWebDriver driver) : BaseStep(driver)
{
    public LoginPage OpenLoginPage()
    {
        Logger.Info("Opening login page...");
        return new LoginPage(Driver, true, true);
    }
}