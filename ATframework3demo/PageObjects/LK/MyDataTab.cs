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
    }
}
