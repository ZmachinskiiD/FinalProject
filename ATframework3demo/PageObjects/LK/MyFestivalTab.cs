using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Constructor;
using OpenQA.Selenium;
using System.IO;

namespace ATframework3demo.PageObjects.LK
{
    public class MyFestivalTab
    {
        IWebDriver Driver { get; }

        public MyFestivalTab(IWebDriver driver = default)
        {
            Driver = driver;
        }
        WebItem publishedButton = new WebItem("//button[@data-target='published'] ","Кнопка перехода на Опубликованные");
        WebItem draftsButton = new WebItem("//button[@data-target='drafts'] ", "Кнопка перехода на Черновики");
        WebItem сreateFestivalButton = new WebItem("//a[@href='/festival_create/'] ", "Кнопка создания фестиваля");

        public MyFestivalCard GetFestivalCardByName(string name)
        {
            string path = $"//div[@class='festival-card'][.//h3[text()='{name}']]";
            return new MyFestivalCard(path);
        }
        public MyFestivalCard GetFestivalCardByID(string id)
        {
            string path = $"//div[@class='festival-card'][.//a[@href=\"/festivals/{id}/\"]]";
            return new MyFestivalCard(path);
        }
        public ConstructorMainInfo GoToConstructor()
        {
            сreateFestivalButton.Click();
            return new ConstructorMainInfo();
        }
        public MyFestivalTab GoToDrafts()
        {
            draftsButton.Click();
            return new MyFestivalTab(Driver);
        }
        public MyFestivalTab GoToPublished()
        {
            publishedButton.Click();
            return new MyFestivalTab(Driver);
        }
    }
    
}
