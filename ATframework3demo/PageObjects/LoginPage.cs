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
    public class LoginPage
    {
        public IWebDriver Driver { get; }
        public PortalInfo portalInfo { get; }
        public LoginPage(PortalInfo portal, IWebDriver driver = default)
        {
            Driver = driver;
            portalInfo = portal;
        }
        public LoginPage(IWebDriver driver = default)
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
        WebItem regBtn =>
            new WebItem("//a[@href='/register']",
                "Кнопка перехода на регистрацию");

        WebItem errorMessage =>
            new WebItem("//div[@id='error-message']",
                "Окно ошибки не правильно введен пароль или логин");
        WebItem infoFavMessage =>
            new WebItem("//div[@class='info-message' and contains(text(),'избранное')]",
                "Сообщение об авторизации, для добавления в избранное");
        WebItem infoParticipateMessage =>
            new WebItem("//div[@class='info-message' and contains(text(),'избранное')]",
                "Сообщение об авторизации, для участия в фестивале");
        


        public LoginPage Login(User user)
        {       
            loginField.SendKeys(user.LoginAkaEmail, Driver);
            if (!pwdField.WaitElementDisplayed(1, Driver))
                loginField.SendKeys(Keys.Enter, Driver);
            pwdField.SendKeys(user.Password, Driver, logInputtedText: false);
            enterBtn.Click();
            return new LoginPage(Driver);
        }
        public SearchPage GoToSearch()
        {
            return new SearchPage();
        }
        public HeaderPage GoToHeader()
        {
            return new HeaderPage();
        }
        public RegisterPage GoToRegister()
        {
            regBtn.Click();
            return new RegisterPage();
        }
        public bool ErrorEmailorPwdDisplayed()
        {
            return errorMessage.WaitElementDisplayed(5);
        }
    }
}
