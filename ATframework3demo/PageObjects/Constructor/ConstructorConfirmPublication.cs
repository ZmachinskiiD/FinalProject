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
        WebItem ErrorWarning = new WebItem("//div[@class='notification error show' ]", "Всплывающее уведомление об ошибке");
        public SearchPage Publish()
        {
            PublishButton.Click();
            return new SearchPage(Driver);
        }
        public bool AssertCantPublishWithoutEvent()
        {
            PublishButton.Click();
            var result = ErrorWarning.AssertTextContains("Создайте хотя бы одно событие");
            if (result == false)
            {
                throw new Exception("Отсутствует предупреждение");
            }
            return result;
        }
        public bool AssertCantPublishWithoutVenue()
        {
            PublishButton.Click();
            var result = ErrorWarning.AssertTextContains("Создайте хотя бы одну площадку");
            if (result == false)
            {
                throw new Exception("Отсутствует предупреждение");
            }
            return result;
        }
        public LKLeftMenu ToDrafts()
        {
            PublishButton.Click();
            return new LKLeftMenu(Driver);
        }
    }
}
