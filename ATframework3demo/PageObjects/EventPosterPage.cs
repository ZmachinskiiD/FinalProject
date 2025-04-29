using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class EventPosterPage
    {
        public EventPosterPage(string path, IWebDriver driver = default)
        {
            Driver = driver;
            Path = path;
        }
        public IWebDriver Driver { get; }
        public string Path { get; }
        WebItem eventDescription =>new WebItem(Path+"//p[@class='venue-subtitle']","Описание площадки");
        public bool assertDescriptionText(string text)
        {
            var result = eventDescription.AssertTextContains(text,$"Ожидался {text}");
            if(!result)
            {
                throw new Exception("Неверное описание");
            }
            return result;
        }
    }
}
