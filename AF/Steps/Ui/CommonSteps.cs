using AF.BaseEntities;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace AF.Steps.Ui;

public class CommonSteps(IWebDriver driver) : BaseStep(driver)
{
    [AllureStep("Get current URL")]
    public string GetCurrentUrl()
    {
        return Driver.Url;
    }
}