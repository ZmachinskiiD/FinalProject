using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.LK
{
    public class MyFestivalCardMenu
    {
        IWebDriver Driver { get; }

        public MyFestivalCardMenu(IWebDriver driver = default)
        {
            Driver = driver;
        }
        WebItem editButton = new WebItem("//a[contains(@class,'festival_edit')]", "Кнопка перехода на редактирование");
        WebItem changeStatusButton = new WebItem("//button[class=\"dropdown-item toggle-status-btn\"]", "Кнопка смены статуса");
    }
}
