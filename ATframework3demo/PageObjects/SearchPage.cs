using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities.Festivalia;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace ATframework3demo.PageObjects
{
    public class SearchPage
    {
        public SearchPage(IWebDriver driver = default)
        {
            activeCheck.WaitElementDisplayed();
            Driver = driver;
        }
        public IWebDriver Driver { get; }

        WebItem activeCheck =>
            new WebItem("//input[@id='activeFilter']",
                "Кнопка показывать прошедшие фестивали");

        WebItem tagBtn(string name) =>
            new WebItem($"//section[@class='tag-filters']//div[contains(@class,'tag') and contains(text(),'{name}')]",
                $"Тег с названием {name}");  
        WebItem emptyStateMessage =>
            new WebItem("//div[@class='no-festivals-message']",
                "Сообщение об отсутствие фестивалей");

        public HeaderPage GoToHeader()
        {
            return new HeaderPage();
        }
        public void findTheFestival(string name)
        {
            WebItem festivalName =
             new WebItem($"//article[@class=\"festival-card\"][.//h3[contains(text(), '{name}')]]",
                $"Кнопка подробнее о фестивале по названию {name}");
            if (!(festivalName.WaitElementDisplayed()))
            {
                throw new Exception("Не найден фестиваль на главной");
            }

        }

        public FestivalPosterPage GetFestivalPosterByName(string name)
        {
            string path = $"//img[@alt='{name}']/ancestor::article[@class='festival-card'][1]";
            return new FestivalPosterPage(path);
        }

    }
}