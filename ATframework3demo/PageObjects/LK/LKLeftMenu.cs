using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class LKLeftMenu
    {
        IWebDriver Driver { get; }

        public LKLeftMenu(IWebDriver driver = default) 
        {
            Driver = driver;
        }
        WebItem myDataButton = new WebItem("//a[@href=\"#data\"]", "Поле перехода на таб мои данные");
        WebItem myFestButton = new WebItem("//a[@href=\"#festivals\"]", "Кнопка перехода на таб мои фестивали");
        WebItem participateButton = new WebItem("//a[@href=\"#participation\"]", "Кнопка перехода на таб участвую");
        WebItem favoritesButton = new WebItem("//a[@href=\"#favorites\"]", "кнопка перехода на таб избранное");
        WebItem notificationButton = new WebItem("//a[@href=\"#notifications\"]", "кнопка перехода на таб уведомления");

        WebItem logoutButton = new WebItem("//button[@class=\"logout-btn\"]", "Кнопка выхода");
    }
}
