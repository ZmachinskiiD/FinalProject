using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class NotificationTab
    {
        IWebDriver Driver { get; }

        public NotificationTab(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
