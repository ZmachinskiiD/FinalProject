using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class Header
    {
        WebItem mainPageBtn= new WebItem("//a[@href='/']", "Кнопка перехода на главную(поиск фестивалей)");
        public Header(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public MainPage GoToMain()
        {
            //Клик в Написать сообщение
            mainPageBtn.Click(); 
            return new MainPage(Driver);
        }
    }
}
