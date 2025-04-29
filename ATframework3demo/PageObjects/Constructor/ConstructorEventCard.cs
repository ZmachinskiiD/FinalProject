using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorEventCard
    {
        public string Path { get; set; }
        IWebDriver Driver { get; }

        public ConstructorEventCard(string path, IWebDriver driver = default)
        {
            Driver = driver;
            Path = path;
        }
        WebItem deleteButton => new WebItem(Path + "//button[@class=\"btn delete-btn\"]", "Кнопка удаления");
        WebItem editButton => new WebItem(Path + "//button[@class=\"btn btn-icon edit-btn\"]", "Кнопка редактирования");
        public ConstructorEventForm OpenForEdit()
        {
            editButton.Click();
            return new ConstructorEventForm();
        }
    }
}
