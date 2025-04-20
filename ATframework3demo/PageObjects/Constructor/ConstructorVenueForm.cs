using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorVenueForm
    {
        public ConstructorVenueForm(IWebDriver driver = default)
        {
            Driver = driver;
        }
        IWebDriver Driver { get; }

        WebItem prevStep = new WebItem("//button[@class='btn back-btn']", "Кнопка перехода назад ");
        WebItem saveCreateVenue = new WebItem("//button[@id=\"createVenueButton\"]", "Кнопка открытия площадки");
        WebItem nextStep = new WebItem("//button[@class='btn next-btn']", "Кнопка перехода на следующий шаг ");
    }
}
