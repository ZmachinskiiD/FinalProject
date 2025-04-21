using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorEventPage
    {
        public ConstructorEventPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
        IWebDriver Driver { get; }
        WebItem addEventToVenueBtn(string name) => new WebItem($"//div[@class='venue-events-block'][.//h3[contains(text(), '{name}')]]//button[@class='btn add-event-btn']", "Кнопка добавления события на площадку");
    }
}
