using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace AF.Core;

/// <summary>
///     Create a new instance of drivers. Could be chrome, firefox, etc.
/// </summary>
public class DriverFactory
{
    /// <summary>
    ///     Create a new instance of the Chrome driver with specific options.
    /// </summary>
    /// <returns></returns>
    public static IWebDriver GetChromeDriver()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--incognito");
        chromeOptions.AddArgument("--no-sandbox");
        chromeOptions.AddArgument("--start-maximized");
        chromeOptions.AddArgument("--disable-notifications");
        chromeOptions.AddArgument("--disable-popup-blocking");
        chromeOptions.AddArgument("--disable-infobars");
        chromeOptions.AddArgument("--disable-extensions");
        chromeOptions.AddArgument("--disable-gpu");
        chromeOptions.AddArgument("--disable-dev-shm-usage");
        chromeOptions.AddArgument("--no-default-browser-check");
        chromeOptions.AddArgument("--no-first-run");
        chromeOptions.AddArgument("--disable-extensions");
        chromeOptions.AddArgument("--disable-search-engine-choice-screen");
        chromeOptions.AddArgument("--remote-debugging-pipe");
        chromeOptions.AddArgument("--ignore-certificate-errors");
        chromeOptions.AddArgument("--headless");


        var driverPath = new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        return new ChromeDriver(driverPath, chromeOptions);
    }
}