using System.Reflection;
using AF.Utils;
using NLog;
using OpenQA.Selenium;

namespace AF.Core;

/// <summary>
///     This class is responsible for initializing and managing the web browser driver.
/// </summary>
public class Browser
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public Browser()
    {
        var downloadPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "Resources");

        if (!Path.Exists(downloadPath))
            Directory.CreateDirectory(downloadPath);

        NLogConfig.Config();
        var browserType = Configurator.ReadConfiguration().BrowserType?.ToLower();

        Driver = browserType switch
        {
            "chrome" => DriverFactory.GetChromeDriver(downloadPath),
            _ => throw new Exception("This browser type didn't find")
        };

        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        _logger.Info($"Browser {browserType} started successfully!");
    }

    public IWebDriver Driver { get; }
}