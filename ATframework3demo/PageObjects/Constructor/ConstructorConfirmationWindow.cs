using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.LK;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorConfirmationWindow
    {
        public ConstructorConfirmationWindow(IWebDriver driver = default)
        {
            Driver = driver;
        }
        IWebDriver Driver { get; }
        WebItem returnButton = new WebItem("//button[@id=\"confirmation-modal-cancel\"]", "Кнопка подтверждения");
        WebItem confirmButton = new WebItem("//button[@id=\"confirmation-modal-confirm\"]", "Кнопка отмены");
        public SearchPage ConfirmPublication()
        {
            confirmButton.Click();
            return new SearchPage();
        }
        public LKLeftMenu ConfirmToDrafts()
        {
            confirmButton.Click();
            return new LKLeftMenu();
        }
    }
}
