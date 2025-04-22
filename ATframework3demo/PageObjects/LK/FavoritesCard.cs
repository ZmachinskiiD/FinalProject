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
        WebItem changeStatusButton => new WebItem(Path + "//i[contains(@class,'favorite')]", "Кнопка добавления/удаления в избранное");
        //TODO разделить на две
        //TODO Вернуться на таб метод
    }
}
