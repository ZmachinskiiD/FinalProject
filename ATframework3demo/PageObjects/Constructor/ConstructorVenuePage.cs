using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorVenuePage
    {
        public ConstructorVenuePage(IWebDriver driver = default)
        {
            Driver = driver;
        }
        IWebDriver Driver { get; }
        WebItem photoInput = new WebItem("//input[@id='venueImage']", "Поле ввода фотографии");
        WebItem NameInput = new WebItem("//input[@id='venueTitle']", "Поле ввода названия");
        WebItem DescInput = new WebItem("//input[@id='venueShortDesc']", "Поле ввода кртакого описания");
        WebItem DescFullInput = new WebItem("//textarea[@id='venueDescription']", "Поле ввода полного описания");
        WebItem SaveBtn = new WebItem("//button[@id='saveVenue']", "Кнопка сохранения");
    }
}
