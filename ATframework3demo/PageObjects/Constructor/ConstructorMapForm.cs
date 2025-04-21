using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorMapForm
    {
        public ConstructorMapForm(IWebDriver driver = default)
        {
            Driver = driver;
        }
        IWebDriver Driver { get; }
        WebItem MapInput = new WebItem("//input[@id=\"festivalMap\"]", "Поле добавления карты");
        WebItem ConfirmAreaButton = new WebItem("//button[@id=\"saveMap\"]", "Кнопка подтверждения областей");
        WebItem PublishButton = new WebItem("//button[@id=\"publishFestival\"]", "Кнопка опубликования");
    }
    


}
