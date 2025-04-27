using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Constructor;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class MyFestivalmenu
    {
        IWebDriver Driver { get; }

        public MyFestivalmenu(IWebDriver driver = default)
        {
            Driver = driver;
        }
        WebItem editButton => new WebItem("//a[@class=\"dropdown-item\"]", "Кнопка открывающая страницу редактирования");
        WebItem changeStatusButton => new WebItem("//i[contains(@class,'fa-toggle')]", "Кнопка переключения статуса");
        public ConstructorMainInfo OpenFestivalForEdit()
        {
            editButton.Click(Driver);
            return new ConstructorMainInfo(Driver);
        }
    }
}