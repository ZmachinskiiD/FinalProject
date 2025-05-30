﻿using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.SeleniumFramework.DriverActions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace atFrameWork2.SeleniumFramework
{
    public class WebDriverActions : BaseDriverActions
    {
        /// <summary>
        /// Создаёт настроенный объект вебдрайвера
        /// </summary>
        /// <returns></returns>
        public static IWebDriver GetNewDriver()
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        /// <summary>
        /// Закрывает текущий драйвер по умолчанию, создаёт новый драйвер по умолчанию и логинит на нём заданного юзера на заданный портал
        /// </summary>
        /// <param name="user"></param>
        /// <param name="portal"></param>
        /// <returns></returns>
        public static SearchPage ReloginWithNewDefaultDriver(User user, PortalInfo portal)
        {
            WebItem.DefaultDriver.Quit();
            WebItem.DefaultDriver = default;
            return new LoginPage(portal)
                .Login(user).GoToSearch();
        }

        /// <summary>
        /// Обновляет текущую страницу
        /// </summary>
        /// <param name="driver"></param>
        public static void Refresh(IWebDriver driver = default)
        {
            Log.Info($"{nameof(Refresh)}");
            driver ??= WebItem.DefaultDriver;
            driver.Navigate().Refresh();
        }

        /// <summary>
        /// Переход на заданный адрес
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="driver"></param>
        public static void OpenUri(Uri uri, IWebDriver driver = default)
        {
            Log.Info($"{nameof(OpenUri)}: {uri}");
            driver ??= WebItem.DefaultDriver;
            driver.Navigate().GoToUrl(uri);
        }

        /// <summary>
        /// Обрабатывает алерт на странице (да\нет). Если алерта нет, то выбросит исключение.
        /// </summary>
        /// <param name="accept"></param>
        /// <param name="driver"></param>
        public static void BrowserAlert(bool accept, IWebDriver driver = default)
        {
            driver ??= WebItem.DefaultDriver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            string result = $"Алерт браузера '{alertText}': нажата кнопка ";

            if (accept)
            {
                alert.Accept();
                result += "ОK";
            }
            else
            {
                alert.Dismiss();
                result += "Отмена";
            }

            Log.Info(result);
        }

        /// <summary>
        /// Переключает контекст драйвера в исходное состояние
        /// </summary>
        /// <param name="driver"></param>
        public static void SwitchToDefaultContent(IWebDriver driver = default)
        {
            Log.Info($"{nameof(SwitchToDefaultContent)}");
            driver ??= WebItem.DefaultDriver;
            driver.SwitchTo().DefaultContent();
        }
        // Переключает на входящий драйвер
        public static void SwitchDefaultDriver(IWebDriver driver)
        {
            Log.Info($"Switch default driver on {driver.Title}");
            WebItem.DefaultDriver = driver;
        }
    }
}
