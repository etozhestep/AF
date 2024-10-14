using AF.BaseEntities;

namespace AF.Tests;

public class UserPopupTests : BaseTest
{
    [SetUp]
    public void Login()
    {
        UserLoginSteps.LoginWithValidCredentials();
    }

    [Test]
    public void UserPopup_OpenPopup_PopupIsDisplayed()
    {
        SettingsPage.SideBar.OpenUserPopup();

        Assert.That(SettingsPage.UserPopup.IsDisplayed, Is.True, "User popup is not displayed");
    }

    [Test]
    public void UserPopup_CheckPopupButton_AllButtonsDisplayed()
    {
        SettingsPage.SideBar.OpenUserPopup();

        Assert.Multiple(() =>
        {
            Assert.That(SettingsPage.UserPopup.ProfileButton.IsDisplayed, Is.True,
                "Profile button is not displayed");
            Assert.That(SettingsPage.UserPopup.ApiButton.IsDisplayed, Is.True,
                "API button is not displayed");
            Assert.That(SettingsPage.UserPopup.LogoutButton.IsDisplayed, Is.True,
                "Logout button is not displayed");
        });
    }

    [Test]
    public void UserPopup_CheckProfileButton_ProfilePageOpened()
    {
        const string expectedProfileTitle = "User profile";
        SettingsPage.SideBar.OpenUserPopup();
        SettingsPage.UserPopup.ProfileButton.Click();
        var actualProfileTitle = ProfilePage.ProfileTitle.Text;

        Assert.Multiple(() =>
        {
            Assert.That(ProfilePage.ProfileTitle.IsDisplayed, Is.True, "Profile page is not displayed");
            Assert.That(actualProfileTitle, Is.EqualTo(expectedProfileTitle),
                "Profile title is not correct. Expected: {0}, Actual: {1}", expectedProfileTitle, actualProfileTitle);
        });
    }
}