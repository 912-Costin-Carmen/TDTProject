
namespace TDTProject
{
    internal class RegatulJocurilor
    {
        protected IWebDriver chromeDriver = new ChromeDriver();
        private string mainPage = "https://regatuljocurilor.ro/ro/";

        private string newsletterPopupCloseBtn = "//div[@class='tm-newsletter-popup-close']//i[@class = 'material-icons clear']";
        private string allowCookiesBtn = "//div[@id='cookieNotice']//button[@class='btn closeFontAwesome']";

        public void waitForPageLoad()
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, new TimeSpan());
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void setResolution1920x1080()
        {
            chromeDriver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        }

        public void goToMainPage()
        {
            chromeDriver.Navigate().GoToUrl(mainPage);
        }

        public void close()
        {
            chromeDriver.Close();
        }

        public void closeNewsletterPopUp()
        {
            click(newsletterPopupCloseBtn);
        }

        public void allowCookies()
        {
            click(allowCookiesBtn);
        }

        public string getTextFromLabel(string Xpath)
        {
            IWebElement label = chromeDriver.FindElement(By.XPath(Xpath));
            return label.Text;
        }

        public int getVisibleElementCount(string Xpath)
        {
            int count = 0;
            var elements =  chromeDriver.FindElements(By.XPath(Xpath));
            foreach (IWebElement elem in elements)
            {
                if (elem.Displayed)
                {
                    count++;
                }
            }
            return count;
        }

        public bool elementIsVisible(string Xpath)
        {
            return chromeDriver.FindElement(By.XPath(Xpath)).Displayed;
        }


        #region Helpers
        public void click(string Xpath)
        {
            IWebElement btn = chromeDriver.FindElement(By.XPath(Xpath));
            btn.Click();
        }
        #endregion Helpers

    }
}
