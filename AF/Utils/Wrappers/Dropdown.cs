using OpenQA.Selenium;

namespace AF.Utils.Wrappers;

public class Dropdown(IWebDriver driver, By locator) : UiElement(driver, locator)
{
    private readonly UiElement _dropDown = new(driver, locator);

    private readonly By _optionsContainerXpath =
        By.XPath("//div[contains(@id, 'Dropdown') and contains(@role, 'listbox')]");

    private readonly By _optionXpath = By.XPath(".//button");


    public void SelectByValue(string value)
    {
        OpenDropDown();
        var options = GetOptions();
        var valueElement = options
            .FirstOrDefault(element =>
                element.Text.Equals(value, StringComparison.OrdinalIgnoreCase)
                || element.Text.StartsWith(value, StringComparison.OrdinalIgnoreCase)
                || element.Text.Contains(value, StringComparison.OrdinalIgnoreCase));

        if (valueElement is null)
            throw new NotFoundException($"Option with value '{value}' not found");

        Actions
            .MoveToElement(valueElement)
            .Click()
            .Perform();
    }

    private IEnumerable<IWebElement> GetOptions()
    {
        var container = Waits.WaitForVisibility(_optionsContainerXpath);
        return container.FindElements(_optionXpath).ToList();
    }

    private void OpenDropDown()
    {
        _dropDown.Click();
    }
}