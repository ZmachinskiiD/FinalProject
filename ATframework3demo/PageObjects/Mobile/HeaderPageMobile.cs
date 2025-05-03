using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.LK;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Mobile
{
    public class HeaderPageMobile
    {
        WebItem searchPageBtn =>
            new WebItem("//div[@class='nav-mobile']//a[@href='/']",
                "Кнопка перехода на главную(поиск фестивалей)");

        WebItem cabinetPageBtn =>
            new WebItem("//div[@class='nav-mobile']//a[@href='/cabinet/']",
                "Кнопка личный кабинет");

        WebItem searchField =>
            new WebItem("//div[@class='nav-mobile']//input[@id='siteSearchInputMobile']",
                "Поле для ввода поиска");

        WebItem searchBtn =>
            new WebItem("//div[@class='nav-mobile']//button[@id='siteSearchBtnMobile']",
                "Кнопка поиска");
        public HeaderPageMobile(IWebDriver driver = default)
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
        public SearchPage FilterByName(string Name)
        {
            searchField.SendKeys(Name);
            searchBtn.Click();
            return new SearchPage(Driver);
        }
    }
}
