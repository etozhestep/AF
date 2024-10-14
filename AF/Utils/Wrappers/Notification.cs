using OpenQA.Selenium;

namespace AF.Utils.Wrappers;

public class Notification(IWebDriver driver, By locator) : UiElement(driver, locator)
{
    private readonly UiElement _uiElement = new(driver, locator);

    public bool IsDisplayed => _uiElement.Displayed;
    public bool IsEnabled => _uiElement.Enabled;
    public string NotificationMessage => _uiElement.FindElement(By.TagName("p")).Text.Trim();
}