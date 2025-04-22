using atFrameWork2.SeleniumFramework;
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
    }
}
