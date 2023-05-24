
using OpenQA.Selenium.Support.UI;

namespace TDTProject
{
    public class NewsletterTests
    {
        #region Attributes
        private RegatulJocurilor regatulJocurilor = new RegatulJocurilor();
        #endregion

        #region SetUp
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            regatulJocurilor.setResolution1920x1080();
            regatulJocurilor.goToMainPage();
            regatulJocurilor.waitForPageLoad();
            regatulJocurilor.closeNewsletterPopUp();
            regatulJocurilor.allowCookies();
        }

        [SetUp]
        public void SetUp()
        {
            setState(Newsletters.expandedState);
        }
        #endregion

        #region Tests
        [Test(Description = Strings.expandAndCollapseListDescription)]
        public void PRexpandAndCollapse()
        {
            setState(Newsletters.expandedState);
            int visibleElements = regatulJocurilor.getVisibleElementCount(Newsletters.sectionXpath);
            Assert.That(visibleElements, Is.EqualTo(28), Strings.expandAndCollapseListErrorMessage);
            setState(Newsletters.collapsedState);
            visibleElements = regatulJocurilor.getVisibleElementCount(Newsletters.sectionXpath);
            Assert.That(visibleElements, Is.EqualTo(12), Strings.expandAndCollapseListErrorMessage);
        }

        [Test]
        // Enter an invalid email address
        emailInput.Clear();
        emailInput.SendKeys("invalid-email");

        // Submit the form
        submitButton.Click();

        // Wait for the error message
        IWebElement errorMessage = wait.Until(ExpectedConditions.ElementExists(By.ClassName("alert-danger")));

        // Verify the error message
        Assert.IsTrue(errorMessage.Text.Contains("Please enter a valid email address"));

        public void PRSectionTextCollapsedList(string expectedText, string Xpath)
        {
            string actualText = regatulJocurilor.getTextFromLabel(Xpath);
            Assert.That(actualText, Is.EqualTo(expectedText), string.Format(Strings.collapsedLIstErrorMessage, expectedText, actualText));
        }
        #endregion

        #region Helpers
        public void setState(string state)
        {
            string currentState = regatulJocurilor.getTextFromLabel(Newsletters.CategoriiXpath);
            if (currentState == state)
            {
                return;
            }
            regatulJocurilor.click(Newsletters.CategoriiXpath);
        }
        #endregion

        #region TearDown
        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            regatulJocurilor.close();
        }
        #endregion
    }
}