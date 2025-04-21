using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ATframework3demo.PageObjects;


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
    }
}
