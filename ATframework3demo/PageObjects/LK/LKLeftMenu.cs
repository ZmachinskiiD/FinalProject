﻿using atFrameWork2.SeleniumFramework;
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

        public MyDataTab goToMyDataTab()
        {
            myDataButton.Click();
            return new MyDataTab(Driver);
        }
        public MyFestivalTab GoToMyFestivalsTab()
        {
            myFestButton.Click();
            return new MyFestivalTab(Driver);
        }
        public ParticipationTab goToParticipationTab()
        {
            participateButton.Click();
            return new ParticipationTab(Driver);
        }
        public FavoriteTab goToFavoriteTab()
        {
            favoritesButton.Click();
            return new FavoriteTab(Driver);
        }
        public NotificationTab goToNotificationTab()
        {
           notificationButton.Click();
            return new NotificationTab(Driver);
        }
        public SearchPage LogOut()
        {
            logoutButton.Click();
            return new SearchPage(Driver);
        }
        public bool assertMyFestivalTabDoNotExist()
        {
     
            var result = myFestButton.WaitElementDisplayed(3);
            if (result == false)
            {
                return result;
            }
            throw new Exception("Таб присутствует а не должен!");
        }
    }
}
