using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities.Festivalia;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class MyFestivalCard
    {
        public string Path { get; set; }
        IWebDriver Driver { get; }

        public MyFestivalCard(string path,IWebDriver driver = default)
        {
            Driver = driver;
            Path = path;
        }
        WebItem moreButton => new WebItem(Path + "//a[@class='details-btn']", "Кнопка подробнее у карточки");
        WebItem changeStatusButton => new WebItem(Path + "//i[contains(@class,'fa-toggle')]", "Кнопка переключения статуса");
        public MyFestivalTab returnToTab()
        {
            return new MyFestivalTab(Driver);
        }
        public FestivalDetailPage goToDetail()

        {
            moreButton.Click();
            return new FestivalDetailPage(Driver);
        }
        public void findTheFestival()
        {
            if (!(moreButton.WaitElementDisplayed()))
            {
                throw new Exception("Не найден фестиваль в ЛК");
            }

        }

    }
}
