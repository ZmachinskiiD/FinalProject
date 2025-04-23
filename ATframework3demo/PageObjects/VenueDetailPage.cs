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

        public EventPosterPage GoToEventByName(string name)
        {
            string path = $"//h3[text()='{name}']/ancestor::div[contains(@class,'timeline-item')][1]";
            return new EventPosterPage(path);
        }
    }
}
