using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class ParticipationCard
    {
        IWebDriver Driver { get; }
        string Path { get; }
        public ParticipationCard(string path, IWebDriver driver = default)
        {
            Driver = driver;
            Path = path;
        }
        WebItem moreButton => new WebItem(Path + "//a[@class='details-btn']", "Кнопка подробнее у карточки");
        WebItem titleCard(string name) => new WebItem(Path + $"//h3[text()='{name}']", $"Название карточки: {name}");
        
        public MyFestivalTab returnToTab()
        {
            return new MyFestivalTab(Driver);
        }
        public FestivalDetailPage goToDetail()
        {
            moreButton.Hover();
            moreButton.Click();
            return new FestivalDetailPage(Driver);
        }
        public bool assertByName(string name)
        {
            bool result = titleCard(name).WaitElementDisplayed(2);
            if (result) 
            {
                titleCard(name).Hover();

            }
            return result;
        }
    }
}
