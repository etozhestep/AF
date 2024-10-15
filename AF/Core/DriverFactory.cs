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
    public static IWebDriver GetChromeDriver(string downloadDirectory)
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--incognito");
        chromeOptions.AddArgument("--no-sandbox");
        chromeOptions.AddAdditionalOption("useAutomationExtension", false);
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
        chromeOptions.AddArgument("--remote-debugging-port=9222");
        chromeOptions.AddArgument("--headless");
        chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
        chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
        chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
        chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
        chromeOptions.AddUserProfilePreference("profile.default_content_settings.popups", 0);
        chromeOptions.AddUserProfilePreference("profile.content_settings.exceptions.automatic_downloads.*.setting", 1);
        chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
        chromeOptions.AddUserProfilePreference("profile.managed_default_content_settings.popups", 0);
        chromeOptions.AddUserProfilePreference("download.extensions_to_open",
            "application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        const string mimeTypes = "application/vnd.ms-excel,application" +
                                 "/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        chromeOptions.AddUserProfilePreference("profile.default_content_settings.popups", 0);
        chromeOptions.AddUserProfilePreference("profile.content_settings.exceptions.automatic_downloads.*.setting", 1);
        chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
        chromeOptions.AddUserProfilePreference("profile.managed_default_content_settings.popups", 0);
        chromeOptions.AddUserProfilePreference("download.extensions_to_open", mimeTypes);

        var driverPath = new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        return new ChromeDriver(driverPath, chromeOptions);
    }
}