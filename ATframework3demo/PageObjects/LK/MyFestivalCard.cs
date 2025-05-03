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
        //WebItem changeStatusButton => new WebItem(Path + "//i[contains(@class,'fa-toggle')]", "Кнопка переключения статуса");
        WebItem menuButton => new WebItem(Path + "//button[@class=\"dropdown-toggle\"]", "Кнопка открывающая меню на карточке");
        public MyFestivalTab ReturnToTab()
        {
            return new MyFestivalTab(Driver);
        }
        public FestivalDetailPage GoToDetail()

        {
            moreButton.Click();
            return new FestivalDetailPage(Driver);
        }
        public void FindTheFestival()
        {
            if (!moreButton.WaitElementDisplayed())
            {
                throw new Exception("Не найден фестиваль в ЛК");
            }

        }
        public MyFestivalmenu OpenMenu()
        {
            menuButton.Click();
            return new MyFestivalmenu(Path, Driver);
        }

    }
}
