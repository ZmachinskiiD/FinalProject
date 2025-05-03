using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class FavoriteTab
    {
        IWebDriver Driver { get; }

        public FavoriteTab(IWebDriver driver = default)
        {
            Driver = driver;
        }
        public FavoritesCard GetFavoriteCard(string name)
        {
            string path = $"//section[@id='favorites']//h3[text()='{name}']/ancestor::div[@class='festival-card']";
            return new FavoritesCard(path);
        }
    }
}
