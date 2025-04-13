using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class ProfilePage
    {
        public ProfilePage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
    }
}
