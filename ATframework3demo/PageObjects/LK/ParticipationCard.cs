using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class ParticipationCard
    {
        IWebDriver Driver { get; }
        String Path { get; }
        public ParticipationCard(string path, IWebDriver driver = default)
        {
            Driver = driver;
            Path = path;
        }
        WebItem moreButton => new WebItem(Path + "//a[@class='details-btn']", "Кнопка подробнее у карточки");
        public MyFestivalTab returnToTab()
        {
            return new MyFestivalTab(Driver);
        }
        public FestivalDetailPage goToDetail()

        {
            moreButton.Click();
            return new FestivalDetailPage(Driver);
        }
    }
}
