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
        WebItem addEventToVenueBtn(string name) => new WebItem($"//div[@class='venue-header'][.//h3[contains(text(), '{name}')]]//button[@class='btn add-event-icon']", "Кнопка добавления события на площадку");
        WebItem OpenEventList(string name) => new WebItem($"//div[@class='venue-header'][.//h3[contains(text(), '{name}')]]//div[@class=\"venue-header-left\"]", "Кнопка раскрытия списка событий");
        public ConstructorEventForm OpenEventFormForVenueByName(string name)
        {
            addEventToVenueBtn(name).Click();
            return new ConstructorEventForm(Driver);
        }
        public ConstructorEventCard GoToEventCard(string name)
        {
            return new ConstructorEventCard($"//article[@class='event-card'][.//h4[contains(text(), '{name}')]]");
        }

    }
}
