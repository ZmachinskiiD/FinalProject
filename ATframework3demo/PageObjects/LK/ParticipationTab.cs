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
            string path = $"//div[@class='festival-card'][.//h3[text()='{name}']]";
            return new ParticipationCard(path);
        }
    }
}
