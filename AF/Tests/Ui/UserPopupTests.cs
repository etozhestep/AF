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
        LaunchesPage.SideBar.OpenUserPopup();

        Assert.That(LaunchesPage.UserPopup.IsDisplayed, Is.True, "User popup is not displayed");
    }

    [Test]
    public void UserPopup_CheckPopupButton_AllButtonsDisplayed()
    {
        LaunchesPage.SideBar.OpenUserPopup();

        Assert.Multiple(() =>
        {
            Assert.That(LaunchesPage.UserPopup.ProfileButton.IsDisplayed, Is.True,
                "Profile button is not displayed");
            Assert.That(LaunchesPage.UserPopup.ApiButton.IsDisplayed, Is.True,
                "API button is not displayed");
            Assert.That(LaunchesPage.UserPopup.LogoutButton.IsDisplayed, Is.True,
                "Logout button is not displayed");
        });
    }

    [Test]
    public void UserPopup_CheckProfileButton_ProfilePageOpened()
    {
        const string expectedProfileTitle = "User profile";
        LaunchesPage.SideBar.OpenUserPopup();
        LaunchesPage.UserPopup.ProfileButton.Click();
        var actualProfileTitle = ProfilePage.ProfileTitle.Text;

        Assert.Multiple(() =>
        {
            Assert.That(ProfilePage.ProfileTitle.IsDisplayed, Is.True, "Profile page is not displayed");
            Assert.That(actualProfileTitle, Is.EqualTo(expectedProfileTitle),
                "Profile title is not correct. Expected: {0}, Actual: {1}", expectedProfileTitle, actualProfileTitle);
        });
    }
}