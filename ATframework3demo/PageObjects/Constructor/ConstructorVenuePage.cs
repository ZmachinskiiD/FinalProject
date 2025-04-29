using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorVenuePage
    {
        public ConstructorVenuePage(IWebDriver driver = default)
        {
            Driver = driver;
        }
        IWebDriver Driver { get; }

        WebItem prevStep = new WebItem("//button[@class='btn back-btn']", "Кнопка перехода назад ");
        WebItem saveCreateVenue = new WebItem("//button[@id=\"createVenueButton\"]", "Кнопка открытия площадки");
        WebItem nextStep = new WebItem("//button[@class='btn next-btn']", "Кнопка перехода на следующий шаг ");

        public ConstructorVenueForm OpenVenueForm()
        {
            saveCreateVenue.Click();
            return new ConstructorVenueForm(Driver);
        }
        public ConstructorVenueCard OpenVenueCard(string name)
        {
            return new ConstructorVenueCard($"//article[.//h3[contains(text(), '{name}')]]");
        }

    }
}
