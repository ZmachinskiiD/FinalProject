using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace ATframework3demo.PageObjects
{
    public class SearchPage
    {
        public SearchPage(IWebDriver driver = default)
        {
            toggleBtn.WaitElementDisplayed();
            Driver = driver;
        }
        public SearchPage(PortalInfo portal,IWebDriver driver = default)
        {
            toggleBtn.WaitElementDisplayed();
            Driver = driver;
            PortalInfo = portal;
        }
        
        public IWebDriver Driver { get; }
        public PortalInfo PortalInfo { get; }

       

        
        WebItem emptyStateMessage =>
            new WebItem("//div[@class='no-festivals-message']",
                "Сообщение об отсутствие фестивалей");
        WebItem toggleBtn =>
            new WebItem("//button[@class='filter-toggle']",
                "Кнопка открытия формы фильтров");
        WebItem nextElemPagination =>
            new WebItem("//div[@class='pagination']//a[contains(@class,'page-link')][last()]",
                "Кнопка следующей страницы пагинации");

        public HeaderPage GoToHeader()
        {
            return new HeaderPage();
        }
        public SearchFilterPage OpenFilterForm()
        {
            toggleBtn.Click();
            return new SearchFilterPage();
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
        public bool assertFestivalDoesntExistOnMain(string name)
        {
            WebItem festivalName =
             new WebItem($"//article[@class=\"festival-card\"][.//h3[contains(text(), '{name}')]]",
                $"Кнопка подробнее о фестивале по названию {name}");
            var result=festivalName.WaitElementDisplayed(3);
            if (result == false)
            {
                return result;
            }
            throw new Exception("Найден фестиваль на главной который должен быть черновиком");

        }
        public FestivalDetailPage goToFestivalPage(string festivalId)
        {
            WebItem festivalButton =
             new WebItem($"//a[@href='/festivals/{festivalId}/']",
                $"Кнопка подробнее о фестивале по ID");
            festivalButton.Click();
           return new FestivalDetailPage();
        }
        public  FestivalDetailPage GoToFestivalPageByName(string name)
        {
            WebItem festivalName =
             new WebItem($"//article[@class=\"festival-card\"][.//h3[contains(text(), '{name}')]]//a",
                $"Кнопка подробнее о фестивале по названию {name}");
            festivalName.Click();
            return new FestivalDetailPage();

        }

        public FestivalPosterPage GetFestivalPosterByName(string name)
        {
            string path = $"//img[@alt='{name}']/ancestor::article[@class='festival-card'][1]";
            return new FestivalPosterPage(path);
        }

    }
}