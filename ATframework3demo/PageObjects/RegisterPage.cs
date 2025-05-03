using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ATframework3demo.PageObjects;
using atFrameWork2.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace ATframework3demo.PageObjects
{
    public class RegisterPage
    {
        public RegisterPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
        public IWebDriver Driver { get; }

        WebItem emailField =>
            new WebItem("//input[@name='email']",
                "Поле для ввода почты");

        WebItem pwdField =>
            new WebItem("//input[@name='password']",
                "Поле для ввода пароля");

        WebItem nameField =>
            new WebItem("//input[@name='name']",
                "Поле для ввода имени");

        WebItem lastNameField =>
            new WebItem("//input[@name='lastName']",
                "Поле для ввода фамилии");

        WebItem organizerCheck =>
            new WebItem("//input[@id='organizer-checkbox']",
                "Чек-бокс для регистрации организатора");

        WebItem regBtn =>
            new WebItem("//button[@type='submit']",
                "Кнопка регистрации");

        WebItem pwdToggle =>
            new WebItem("//i[contains(@class,'toggle-password')]",
                "Глаз для пароля");

        WebItem errorEmailMsg =>
            new WebItem("//div[@id='error-message' and contains(text(),'email')]",
                "Окно ошибки email уже существует");

        WebItem errorPwdMsg =>
            new WebItem("//div[@id='error-message' and contains(text(),'Пароль')]",
                "Окно ошибки длины пароля");

        

        public RegisterPage CompleteForm(User user)
        {
            emailField.SendKeys(user.LoginAkaEmail);
            pwdField.SendKeys(user.Password);
            nameField.SendKeys(user.Name);
            lastNameField.SendKeys(user.LastName);
            if (user.Organizer)
            {
                organizerCheck.Click();
            }
            return new RegisterPage();
        }
        
        public LoginPage GoToLoginPage()
        {
            regBtn.Click();
            return new LoginPage();
        }
        public bool EmailIsExist()
        {
            return errorEmailMsg.WaitElementDisplayed(3);

        }
        public void ConfirmAlert()
        {
            Thread.Sleep(3000);
            WebDriverActions.BrowserAlert(true);    
        }
        public HeaderPage GoToHeader()
        {
            return new HeaderPage();
        }
        public RegisterPage CreateAccount(User user)
        {
            regBtn.Click();
            if (user.Organizer)
            {
                this.ConfirmAlert();
            }
            return new RegisterPage();
        }
        public LoginPage GoToLogin()
        {
            return new LoginPage();
        }
    }
}
