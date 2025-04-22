using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

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

        public MyFestivalCard getFestivalCardByName(string name)
        {
            string path = $"//div[@class='festival-card'][.//h3[text()='{name}']]";
            return new MyFestivalCard(path);
        }
    }
    
}
