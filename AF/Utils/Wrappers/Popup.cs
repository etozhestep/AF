using OpenQA.Selenium;

namespace AF.Utils.Wrappers;

public class Popup(IWebDriver driver, By locator) : UiElement(driver, locator)
{
    private readonly By _locator = locator;
    private readonly UiElement? _popupContainer = new(driver, locator);

    public bool IsDisplayed => _popupContainer!.Displayed;
    public bool IsEnabled => _popupContainer!.Enabled;
    public string PopupText => _popupContainer!.Text;

    public void WaitForPopup()
    {
        if (_popupContainer != null) Waits.WaitForVisibility(_locator);
    }
}