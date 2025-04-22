using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class FavoriteTab
    {
        IWebDriver Driver { get; }

        public FavoriteTab(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
