using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorEventPage
    {
        public ConstructorEventPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
        IWebDriver Driver { get; }
    }
}
