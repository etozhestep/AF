using OpenQA.Selenium;

namespace AF.Utils.Wrappers;

public class Field(IWebDriver driver, By locator) : UiElement(driver, locator)
{
    private readonly UiElement _uiElement = new(driver, locator);

    public bool IsDisplayed => _uiElement.Displayed;
    public bool IsEnabled => _uiElement.Enabled;
    public string FieldText => _uiElement.Text;

    public void SendText(string? text)
    {
        _uiElement.SendKeys(text);
    }

    public void ClickEnter()
    {
        _uiElement.SendKeys(Keys.Enter);
    }
}