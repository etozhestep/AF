using OpenQA.Selenium;

namespace AF.Utils.Wrappers;

public class Checkbox : UiElement
{
    private readonly UiElement _checkbox;

    public Checkbox(IWebDriver driver, IWebElement element) : base(driver, element)
    {
        _checkbox = new UiElement(driver, element);
    }

    public Checkbox(IWebDriver driver, By locator) : base(driver, locator)
    {
        _checkbox = new UiElement(driver, locator);
    }

    public bool IsDisplayed => _checkbox.Displayed;
    private bool IsChecked => _checkbox.GetAttribute("class")!.Contains("checked");

    public void Check()
    {
        if (!IsChecked) _checkbox.Click();
    }
}