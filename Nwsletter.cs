using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


class  Program
{
    static void  Main(string[] args)
    {       // Set up the WebDriver
        IWebDriver driver = new ChromeDriver();  // Change this to the appropriate WebDriver for your browser

        // Open the website
        driver.Navigate().GoToUrl("https://www.regatuljocurilor.ro/");

        // Find the newsletter subscription form
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement newsletterForm = wait.Until(ExpectedConditions.ElementExists(By.Id("newsletter_form")));

        // Enter the email address
        IWebElement emailInput = newsletterForm.FindElement(By.Name("email"));
        emailInput.SendKeys("example@example.com");

        // Submit the form
        IWebElement submitButton = newsletterForm.FindElement(By.CssSelector("button[type='submit']"));
        submitButton.Click();

        // Wait for the success message
        IWebElement successMessage = wait.Until(ExpectedConditions.ElementExists(By.ClassName("alert-success")));

        // Verify the success message
        Assert.IsTrue(successMessage.Text.Contains("Thank you for subscribing!"));

        // Close the browser
        driver.Quit();
    }
}

