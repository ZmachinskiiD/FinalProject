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
    }
}
