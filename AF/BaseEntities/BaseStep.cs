using AF.Pages;
using AF.Utils.Wrappers;
using NLog;
using OpenQA.Selenium;

namespace AF.BaseEntities;

/// <summary>
///     Base class for all steps. Contains common methods and properties.
/// </summary>
/// <param name="driver"></param>
public abstract class BaseStep(IWebDriver driver)
{
    protected readonly Logger Logger = LogManager.GetCurrentClassLogger();

    protected readonly LoginPage LoginPage = new(driver);
    protected readonly SettingsPage SettingsPage = new(driver);
    protected readonly Waits Waits = new(driver);

    protected IWebDriver Driver => driver;
}