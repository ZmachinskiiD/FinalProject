using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class ParticipationTab
    {
        IWebDriver Driver { get; }

        public ParticipationTab(IWebDriver driver = default)
        {
            Driver = driver;
        }
        WebItem sectionCards => new WebItem($"//section[@id='participation']", "Секция с карточками");
        public ParticipationCard GetParticipationCardByName(string name)
        {
            string path = $"//section[@id='participation']//h3[text()='{name}']/ancestor::div[@class='festival-card']";
            return new ParticipationCard(path);
        }
    }
}
