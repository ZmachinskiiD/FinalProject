using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class FavoritesCard
    {
        public string Path { get; set; }
        IWebDriver Driver { get; }

        public FavoritesCard(string path, IWebDriver driver = default)
        {
            Driver = driver;
            Path = path;
        }
        WebItem moreButton => new WebItem(Path + "//a[@class='details-btn']", "Кнопка подробнее у карточки");
        WebItem deleteFromFavoritesButton => new WebItem(Path + "//button[class='action-btn favorite active']", "Кнопка удаления из избранного");
        WebItem addToFavoritesButton => new WebItem(Path + "//button[class='action-btn favorite']", "Кнопка добавления в избранное");
        WebItem titleCard(string name) => new WebItem(Path + $"//h3[text()='{name}']",$"Название карточки: {name}");
        public  FavoriteTab returnToTab()
        {
            return new FavoriteTab(Driver);
        }
        public FestivalDetailPage goToDetail()

        {
            moreButton.Click();
            return new FestivalDetailPage(Driver);
        }

        public bool assertByName(string name)
        {
            return titleCard(name).WaitElementDisplayed();
        }

    }
}
