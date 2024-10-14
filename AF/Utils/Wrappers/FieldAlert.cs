using OpenQA.Selenium;

namespace AF.Utils.Wrappers;

public class FieldAlert(IWebDriver driver, By locator) : UiElement(driver, locator)
{
    private readonly UiElement _uiElement = new(driver, locator);

    public bool IsDisplayed => _uiElement.Displayed;
}