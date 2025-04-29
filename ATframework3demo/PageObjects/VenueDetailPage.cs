using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class VenueDetailPage
    {
        public VenueDetailPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
        public IWebDriver Driver { get; }
        WebItem venueTitle =>
            new WebItem("//h1[@class='venue-title']",
                "Название площадки");
        WebItem venueDescription =>
          new WebItem("//p[@class='venue-subtitle']",
              "Описание площадки");

        public EventPosterPage GoToEventByName(string name)
        {
            string path = $"//h3[text()='{name}']/ancestor::div[contains(@class,'timeline-item')][1]";
            return new EventPosterPage(path);
        }
        public bool assertTitle(string Title)
        {
            var result = venueTitle.AssertTextContains(Title, $"Ожидалось {Title}");
            if (!result)
            {
                throw new Exception("Неверное название");
            }
            return result;
        }
        public bool assertDescription(string Description)
        {
            var result = venueDescription.AssertTextContains(Description, $"Ожидалось {Description}");
            if (!result)
            {
                throw new Exception("Неверное описание");
            }
            return result;
        }
        public EventPosterPage FindEventByName(string name)
        {
            return new EventPosterPage($"//div[@class='item-content'][.//h3[contains(text(), '{name}')]]");
        }
    }
}
