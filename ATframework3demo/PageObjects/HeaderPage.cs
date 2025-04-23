using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.LK;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class HeaderPage
    {
        WebItem searchPageBtn =>
            new WebItem("//a[@href='/']",
                "Кнопка перехода на главную(поиск фестивалей)");

        WebItem cabinetPageBtn =>
            new WebItem("//div[@class='nav-desktop']//a[@href='/cabinet/']",
                "Кнопка личный кабинет");

        WebItem searchField =>
            new WebItem("//input[@id='siteSearchInput']",
                "Поле для ввода поиска");

        WebItem searchBtn =>
            new WebItem("//button[@id='siteSearchBtn']",
                "Кнопка поиска");
        public HeaderPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public SearchPage GoToSearch()
        {
            //Клик в Написать сообщение
            searchPageBtn.Click(); 
            return new SearchPage(Driver);
        }
        public LoginPage GoToLogin()
        {
            cabinetPageBtn.Click();
            return new LoginPage();
        }
        public LKLeftMenu GoToLK()
        {
            cabinetPageBtn.Click();
            return new LKLeftMenu();
        }
    }
}
