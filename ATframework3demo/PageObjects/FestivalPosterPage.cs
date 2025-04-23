using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class FestivalPosterPage
    {
        public FestivalPosterPage(string path, IWebDriver driver = default)
        {
            Driver = driver;
            Path = path;
        }
        public IWebDriver Driver { get; }
        public string Path { get; }
        WebItem likeBtn =>
            new WebItem(Path + "//button[contains(@class,'action-btn favorite')]",
                "Кнопка добавить в ибзранное по названию фестиваля");
        WebItem participatingBtn =>
           new WebItem(Path + "//button[contains(@class,'action-btn participate')]",
               "Кнопка добавить участвую по названию фестиваля");
        WebItem detailBtn =>
            new WebItem("//a[contains(@class,'details-btn')]",
                $"Кнопка подробнее о фестивале по названию");
        public SearchPage GoToSearch()
        {
            return new SearchPage();
        }
        

    }
}
