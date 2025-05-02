using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class VenuePosterPage
    {
        public VenuePosterPage(string path, IWebDriver driver = default)
        {
            Driver = driver;
            Path = path;
        }
        public IWebDriver Driver { get; }
        public string Path { get; }
        WebItem venueProgramBtn =>
            new WebItem(Path + "//a[contains(@href,'/venues/')]",
                "Кнопка перехода на программу площадки");
        public VenueDetailPage GoToVenueDetail()
        {
            venueProgramBtn.Click();
            return new VenueDetailPage();
        }
        public bool assertVenueDoesntExist()
        {
            var result = venueProgramBtn.WaitElementDisplayed(3);
            if (result == false)
            {
                return result;
            }
            throw new Exception("Найдена площадка которую должны были удалить");
        }


        
    }
}
