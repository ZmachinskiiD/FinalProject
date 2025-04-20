using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Constructor
{
    public class ConstructorMainInfo
    {
        public ConstructorMainInfo(IWebDriver driver = default)
        {
            Driver = driver;
        }
        IWebDriver Driver { get; }
        WebItem photoInput= new WebItem("//input[@id='festivalImage']", "Поле ввода фотографии");
        WebItem NameInput = new WebItem("//input[@id='festivalTitle']", "Поле ввода названия");
        WebItem DescInput = new WebItem("//input[@id='festivalShortDesc']", "Поле ввода кртакого описания");
        WebItem DescFullInput = new WebItem("//textarea[@id='festivalShortDesc']", "Поле ввода полного описани");
        WebItem StartInput = new WebItem("//input[@id='festivalStartAt']", "Поле вводы даты начала");
        WebItem EndInput = new WebItem("///input[@id='festivalEndAt']", "Поле ввода даты конца");

        //TODO разобраться с тегами

        WebItem saveAsDraft= new WebItem("//button[@class='btn save-btn']", "Кнопка сохранения как черновик");
        WebItem nextStep = new WebItem("//button[@class='btn next-btn']", "Кнопка перехода на следующий шаг ");

    }
}
