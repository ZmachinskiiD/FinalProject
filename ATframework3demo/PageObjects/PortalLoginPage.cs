using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ATframework3demo.PageObjects;
using ATframework3demo.BaseFramework.BitrixCPinterraction;

namespace atFrameWork2.PageObjects
{
    class PortalLoginPage : BaseLoginPage
    {
        IWebDriver Driver { get; }

        public PortalLoginPage(PortalInfo portal, IWebDriver driver = default) : base(portal)
        {
            Driver = driver;
        }
        WebItem loginField =>
            new WebItem("//input[@name='login']",
                "Поле для ввода логина");
        WebItem pwdField => 
            new WebItem("//input[@name='password']",
                "Поле для ввода пароля");

        WebItem rememberCheck =>
            new WebItem("//input[@id='USER_REMEMBER']",
                "Чек-бокс запомнить меня");

        WebItem enterBtn =>
            new WebItem("//button[@type='submit']",
                "Кнопка войти");

        WebItem pwdToggle =>
            new WebItem("//i[contains(@class,'toggle-password')]",
                "Глаз для пароля");


        public SearchPage Login(User admin)
        {
            WebDriverActions.OpenUri(portalInfo.PortalUri, Driver);         
            loginField.SendKeys(admin.LoginAkaEmail, Driver);
            if (!pwdField.WaitElementDisplayed(1, Driver))
                loginField.SendKeys(Keys.Enter, Driver);
            pwdField.SendKeys(admin.Password, Driver, logInputtedText: false);
            enterBtn.Click();
            return new SearchPage(Driver);
        }
        public SearchPage NoLogin()
        {
            WebDriverActions.OpenUri(portalInfo.PortalUri, Driver);
            var header = new HeaderPage();
            header.GoToMain();
            return new SearchPage(Driver);
        }
    }
}
