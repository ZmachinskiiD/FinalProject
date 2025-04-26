using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities.Festivalia;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorEventForm
    {
        public ConstructorEventForm(IWebDriver driver = default)
        {
            Driver = driver;
        }
        IWebDriver Driver { get; }
        WebItem photoInput = new WebItem("//input[@id=\"eventImage\"]", "Поле ввода фотографии");
        WebItem NameInput = new WebItem("//input[@id='eventTitle']", "Поле ввода названия");
        WebItem DescInput = new WebItem("//input[@id=\"eventDescription\"]", "Поле ввода описани");
        WebItem StartInput = new WebItem("//input[@id=\"eventStartAt\"]", "Поле ввода начала");
        WebItem EndInput = new WebItem("//input[@id=\"eventEndAt\"]", "Поле ввода конца");
        WebItem BtnSave = new WebItem("//button[@id=\"saveEvent\"]", "Кнопка сохранения события");

        public ConstructorEventPage saveChanges()
        {
            BtnSave.Click();
            return new ConstructorEventPage(Driver);
        }
        public ConstructorEventForm passData(Event Event)
        {
            photoInput.SendKeys(Event.PhotoPath);
            NameInput.SendKeys(Event.Name);
            DescInput.SendKeys(Event.Description);

            EndInput.SendKeys(Event.DateEnd);
            EndInput.SendKeys(Keys.ArrowRight);
            EndInput.SendKeys(Event.TimeEnd);

            StartInput.SendKeys(Event.DateStart);
            StartInput.SendKeys(Keys.ArrowRight);
            StartInput.SendKeys(Event.TimeStart);
            return new ConstructorEventForm(Driver);
        }


    } 
}
