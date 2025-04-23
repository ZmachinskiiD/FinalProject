using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class FestivalDetailPage
    {
        public FestivalDetailPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
        public IWebDriver Driver { get; }

        WebItem likeBtn =>
            new WebItem("//button[contains(@class,'action-btn favorite')]",
                "Кнопка избранное");
        WebItem participateBtn =>
            new WebItem("//button[contains(@class,'action-btn participate')]",
                "Кнопка участвую");
        WebItem festivalTitle =>
            new WebItem("//*[@class='festival-title']",
                "Название фестиваля");
        WebItem fistivalDescription =>
            new WebItem("//*[@class='festival-description']",
                "Описание фестиваля");
        WebItem mapCanvas =>
            new WebItem("//canvas[@id='mapCanvas']",
                "Карта фестиваля");

        public VenuePosterPage GetVenueByName(string name)
        {
            string path = $"//h3[text()='{name}']/ancestor::article[@class='venue-card']";
            return new VenuePosterPage(path);
        }


    }
}
