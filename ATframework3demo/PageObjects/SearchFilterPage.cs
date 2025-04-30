using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class SearchFilterPage
    {
        public SearchFilterPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        WebItem closeFormBtn =>
            new WebItem("//button[contains(@class,'close-filters')]",
                "Кнопка закрытия формы фильтров");
        WebItem activeCheck =>
           new WebItem("//input[@id='activeFilter']",
               "Кнопка показывать прошедшие фестивали");
        WebItem applyBtn =>
            new WebItem("//button[@class='apply-filters primary-button']",
                "Кнопка принять фильтры");
        WebItem resetBtn =>
            new WebItem("//button[@class='reset-filters ghost-button']",
                "Сбросить фильтры");
        WebItem tagBtn(string name) =>
            new WebItem($"//div[contains(@class,'tag')]//span[text()='{name}']",
                $"Тег с названием {name}");
        public SearchPage CloseFilter()
        {
            closeFormBtn.Hover();
            closeFormBtn.Click();
            return new SearchPage();
        }
        public SearchPage ApplyChangesAndCloseFilter()
        {
            applyBtn.Hover();
            applyBtn.Click();
            return new SearchPage();
        }
        public SearchFilterPage ChooseTag(string name)
        {
            tagBtn(name).Hover();
            tagBtn(name).Click();
            return new SearchFilterPage();
        }
        public SearchFilterPage ChooseNonActiveFilter()
        {
            activeCheck.Hover();
            activeCheck.Click();
            return new SearchFilterPage();
        }

    }
}
