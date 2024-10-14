using AF.Utils.Wrappers;
using OpenQA.Selenium;

namespace AF.Pages.Popup;

public class UserPopup(IWebDriver driver) : Utils.Wrappers.Popup(driver, By.XPath(PopupContainerXpath))
{
    private const string PopupContainerXpath = "//div[contains(@class,'userBlock__menu--')]";
    private readonly By _apiButtonXpath = By.XPath(PopupContainerXpath + "//a[contains(@href,'api')]");
    private readonly By _logoutButtonXpath = By.XPath(PopupContainerXpath + "//*[contains(text(),'Logout')]");
    private readonly By _profileButtonXpath = By.XPath(PopupContainerXpath + "//a[contains(@href,'profile')]");
    public Button ProfileButton => new(Driver, _profileButtonXpath);
    public Button ApiButton => new(Driver, _apiButtonXpath);
    public Button LogoutButton => new(Driver, _logoutButtonXpath);
}