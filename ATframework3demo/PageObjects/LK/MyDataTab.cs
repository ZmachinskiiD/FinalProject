using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class MyDataTab
    {
        IWebDriver Driver { get; }
        public MyDataTab(IWebDriver driver = default)
        {
            Driver = driver;
        }
        WebItem emailTitle(string email) =>
            new WebItem($"//span[contains(text(),'Email')]/following::span[text()='{email}']",
                $"Email {email} в данных личного кабинета");
        public bool EmailIsDisplayed(string email)
        {
            return emailTitle(email).WaitElementDisplayed();
        }
    }
}
