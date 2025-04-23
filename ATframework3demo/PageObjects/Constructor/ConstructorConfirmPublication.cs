using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorConfirmPublication
    {
        IWebDriver Driver { get; }
        public ConstructorConfirmPublication(IWebDriver driver = default)
        {
            Driver = driver;
        }
        WebItem PublishButton = new WebItem("//button[@id=\"confirmPublish\"]", "Кнопка обупликования");
        WebItem DeclineButton = new WebItem("//button[@id=\"cancelPublish\"]", "Кнопка отмены");
        public SearchPage Publish()
        {
            PublishButton.Click();
            return new SearchPage(Driver);
        }
    }
}
