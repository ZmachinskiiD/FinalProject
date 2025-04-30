using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.LK;
using ATframework3demo.TestEntities.Festivalia;
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
        WebItem DescFullInput = new WebItem("//textarea[@id='festivalDescription']", "Поле ввода полного описани");
        WebItem StartInput = new WebItem("//input[@id='festivalStartAt']", "Поле вводы даты начала");
        WebItem EndInput = new WebItem("//input[@id='festivalEndAt']", "Поле ввода даты конца");
        WebItem TagInput = new WebItem("//input[@class='select2-search__field']", "Оле выбора тэга");
        WebItem ErrorWarning = new WebItem("//div[@class='notification error show' ]", "Всплывающее уведомление об ошибке");
        WebItem confirmBtn = new WebItem("//button[@id='confirmation-modal-confirm']", "Кнопка принять перенос в/из черновика");
        WebItem TagSearch(string name) => new WebItem($"//option[contains(text(), '{name}')]", $"Выбор тэга по имени '{name}'  ");


        WebItem saveAsDraft= new WebItem("//button[@id=\"saveFestivalDetails\"]", "Кнопка сохранения как черновик");
        //WebItem nextStep = new WebItem("//button[@class='btn next-btn']", "Кнопка перехода на следующий шаг ");

        public ConstructorMainInfo PassData(Festival festival)

        {
            photoInput.SendKeys(festival.PhotoPath);
            NameInput.SendKeys(festival.Name);
            DescInput.SendKeys(festival.ShortDescription);
            DescFullInput.SendKeys(festival.Description);
            EndInput.SendKeys(festival.DateEnd);
            StartInput.SendKeys(festival.DateStart);
            return new ConstructorMainInfo(Driver);
        }
        public ConstructorMainInfo ClearData()

        {
            NameInput.SendKeys(Keys.Control + "a");
            NameInput.SendKeys(Keys.Delete);
            DescInput.SendKeys(Keys.Control + "a");
            DescInput.SendKeys(Keys.Delete);
            DescFullInput.SendKeys(Keys.Control + "a");
            DescFullInput.SendKeys(Keys.Delete);
            EndInput.SendKeys(Keys.Backspace);
            StartInput.SendKeys(Keys.Backspace);
            return new ConstructorMainInfo(Driver);
        }
        public ConstructorMainInfo SelectTag(string name)
        {
            TagInput.SendKeys(name);
            TagInput.SendKeys(Keys.Enter);
            return new ConstructorMainInfo(Driver);
        }
        public ConstructorMainInfo SaveData()
        {
            saveAsDraft.Click();
            return new ConstructorMainInfo(Driver);
        }
        public bool AssertIncorrectStartEndDate()
        {
            var result=ErrorWarning.AssertTextContains("Дата окончания не может быть раньше даты начала");
            if (result == false)
            {
                throw new Exception("отстутсвует уведомление об ошибке");
            }
            return result;
        }
        public bool AssertStartDateIsIncorrect()
        {
            var result = ErrorWarning.AssertTextContains("Дата начала не может быть раньше сегодняшнего дня");
            if (result == false)
            {
                throw new Exception("отстутсвует уведомление об ошибке");
            }
            return result;
        }
        public LKLeftMenu ConfirmChangePublished()
        {
            confirmBtn.Click();
            return new LKLeftMenu();
        }

    }
}
