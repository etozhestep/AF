using AF.Core;
using AF.Pages;
using AF.Steps;
using AF.Steps.Ui;
using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace AF.BaseEntities;

/// <summary>
///     Base class for all tests. Contains common methods and properties. Create instances of Steps and Pages in Setup.
/// </summary>
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseTest : BaseApiTest
{
    private IWebDriver _driver;
    protected CommonSteps CommonSteps;
    protected LaunchesPage LaunchesPage;
    protected LoginPage LoginPage;
    protected NavigationSteps NavigationSteps;
    protected ProfilePage ProfilePage;
    protected UserLoginSteps UserLoginSteps;


    [SetUp]
    [AllureBefore("Start the browser")]
    public void SetupUi()
    {
        _driver = new Browser().Driver;
        UserLoginSteps = new UserLoginSteps(_driver);
        NavigationSteps = new NavigationSteps(_driver);
        LoginPage = new LoginPage(_driver);
        LaunchesPage = new LaunchesPage(_driver);
        CommonSteps = new CommonSteps(_driver);
        ProfilePage = new ProfilePage(_driver);
    }

    /// <summary>
    ///     Quite and dispose the browser after each test class.
    ///     If the test failed, make a screenshot and attach it to the report.
    /// </summary>
    [TearDown]
    [AllureAfter("Dispose the browser")]
    public void TearDownUi()
    {
        try
        {
            Logger.Info("Test failed. Making a screenshot...");
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var screenshotByte = screenshot.AsByteArray;
            AllureApi.AddAttachment("screenshot", "image/png", screenshotByte);
        }
        finally
        {
            Logger.Info("Quiting the browser...");
            _driver.Quit();
        }
    }
}