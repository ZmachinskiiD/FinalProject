using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Constructor;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class MyFestivalmenu
    {
        IWebDriver Driver { get; }
        string Path { get; }

        public MyFestivalmenu(string path = "", IWebDriver driver = default)
        {
            Driver = driver;
            Path = path;
        }
        WebItem editButton => new WebItem(Path + "//a[@class=\"dropdown-item\"]", "Кнопка открывающая страницу редактирования");
        WebItem changeStatusButton => new WebItem(Path + "//i[contains(@class,'fa-toggle')]", "Кнопка переключения статуса");
        public ConstructorMainInfo OpenFestivalForEdit()
        {
            editButton.Hover(Driver);
            editButton.Click(Driver);
            return new ConstructorMainInfo(Driver);
        }
        public ConstructorConfirmPublication pressTheChangeStatusButton()
        {
            changeStatusButton.Hover(Driver);
            changeStatusButton.Click(Driver);
            return new ConstructorConfirmPublication(Driver);
        }
    }
}