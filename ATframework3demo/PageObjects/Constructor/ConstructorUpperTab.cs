using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorUpperTab
    {
        public ConstructorUpperTab(IWebDriver driver = default)
        {
            Driver = driver;
           
        }
        IWebDriver Driver { get; }
        WebItem MainStep = new WebItem("//button[@id=\"step1\"]", "Кнопка перехода на страницу добавления основной информации");
        WebItem VenueStep = new WebItem("//button[@id=\"step2\"]", "Кнопка перехода на страницу добавления площадок");
        WebItem EventStep = new WebItem("//button[@id=\"step3\"]", "Кнопка перехода на страницу добавления событий");
        WebItem MapStep = new WebItem("//button[@id=\"step4\"]", "Кнопка перехода на страницу добавления карты");

        public ConstructorMainInfo goToMainInfo()
        {
            MainStep.Click();
            return new ConstructorMainInfo(Driver);
        }
        public ConstructorVenuePage goToVenuePage()
        {
            VenueStep.Click();
            return new ConstructorVenuePage(Driver);
        }
        public ConstructorEventPage goToEventPage()
        {
            EventStep.Click();
            return new ConstructorEventPage(Driver);
        }
        public ConstructorMapForm goTomapPage()
        {
            MapStep.Click();
            return new ConstructorMapForm(Driver);
        }
    }
}
