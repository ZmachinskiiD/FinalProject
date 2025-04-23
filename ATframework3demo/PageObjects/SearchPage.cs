using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

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

        WebItem likeBtn(string name) =>
            new WebItem($"//img[@alt='{name}']/following::button[contains(@class,'action-btn favorite')]",
                $"Кнопка добавить в ибзранное по названию фестиваля: {name}");

        WebItem participateBtn(string name) =>
            new WebItem($"//img[@alt='{name}']/following::button[contains(@class,'action-btn participate')]",
                $"Кнопка добавить участвую по названию фестиваля: {name}");

        WebItem detailBtn(string name) =>
            new WebItem($"//img[@alt='{name}']/following::a[contains(@class,'details-btn')]",
                $"Кнопка подробнее о фестивале по названию {name}");

        WebItem emptyStateMessage =>
            new WebItem("//div[@class='no-festivals-message']",
                "Сообщение об отсутствие фестивалей");

        public HeaderPage SwitchToHeader()
        {
            return new HeaderPage();
        }

    }
}