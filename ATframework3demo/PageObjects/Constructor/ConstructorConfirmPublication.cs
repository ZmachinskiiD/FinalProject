using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.LK;
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
        WebItem PublishButton = new WebItem("//button[@id=\"confirmation-modal-confirm\"]", "Кнопка обупликования");
        WebItem DeclineButton = new WebItem("//button[@id=\"cancelPublish\"]", "Кнопка отмены");
        public SearchPage Publish()
        {
            PublishButton.Click();
            return new SearchPage(Driver);
        }
        public LKLeftMenu ToDrafts()
        {
            PublishButton.Click();
            return new LKLeftMenu(Driver);
        }
    }
}
