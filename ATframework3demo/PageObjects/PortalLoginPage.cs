using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ATframework3demo.PageObjects;

namespace atFrameWork2.PageObjects
{
    class PortalLoginPage : BaseLoginPage
    {
        IWebDriver Driver { get; }

        public PortalLoginPage(PortalInfo portal, IWebDriver driver = default) : base(portal)
        {
            Driver = driver;
        }

        public MainPage Login(User admin)
        {
            WebDriverActions.OpenUri(portalInfo.PortalUri, Driver);
            var loginField = new WebItem("//input[@name='login']", "Поле для ввода логина");
            var pwdField = new WebItem("//input[@name='password']", "Поле для ввода пароля");
            loginField.SendKeys(admin.LoginAkaEmail, Driver);
            if (!pwdField.WaitElementDisplayed(1, Driver))
                loginField.SendKeys(Keys.Enter, Driver);
            pwdField.SendKeys(admin.Password, Driver, logInputtedText: false);
            pwdField.SendKeys(Keys.Enter, Driver);
            return new MainPage(Driver);
        }
        public MainPage NoLogin()
        {
            WebDriverActions.OpenUri(portalInfo.PortalUri, Driver);
            var header = new Header();
            header.GoToMain();
            return new MainPage(Driver);
        }
    }
}
