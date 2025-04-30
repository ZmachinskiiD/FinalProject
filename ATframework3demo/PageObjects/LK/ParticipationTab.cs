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
        public ParticipationCard GetParticipationCardByName(string name)
        {
            string path = $"//section[@id='participation']//h3[text()='{name}']/ancestor::div[@class='festival-card']";
            return new ParticipationCard(path);
        }
    }
}
