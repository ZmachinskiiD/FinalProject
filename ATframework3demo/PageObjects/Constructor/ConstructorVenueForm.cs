using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities.Festivalia;
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
        WebItem photoInput = new WebItem("//input[@id='venueImage']", "Поле ввода фотографии");
        WebItem NameInput = new WebItem("//input[@id='venueTitle']", "Поле ввода названия");
        WebItem DescInput = new WebItem("//input[@id='venueShortDesc']", "Поле ввода кртакого описания");
        WebItem DescFullInput = new WebItem("//textarea[@id='venueDescription']", "Поле ввода полного описания");
        WebItem SaveBtn = new WebItem("//button[@id='saveVenue']", "Кнопка сохранения");
        
        public ConstructorVenueForm passData(Venue venue)
        {
            photoInput.SendKeys(venue.PhotoPath);
            NameInput.SendKeys(venue.Name);
            DescFullInput.SendKeys(venue.Description);
            DescInput.SendKeys(venue.ShortDescription);
            return new ConstructorVenueForm(Driver);
        }
        public ConstructorVenuePage saveChanges()
        {
            SaveBtn.Click();
            return new ConstructorVenuePage(Driver);
        }
    }
}
