using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace atFrameWork2.TestCases
{
    public class Case_Bitrix24_Tasks : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
            {
                new TestCase("Создание задачи", homePage => CreateTask(homePage)),
                new TestCase("Редактирование задачи", (MainPage homePage) => throw new NotImplementedException("Заглушка теста редактирования задачи")),
                new TestCase("Удаление задачи", (MainPage homePage) => { Thread.Sleep(5000); Log.Error("kukus"); }),
            };
        }

        public static void CreateTask(MainPage homePage)
        {
            var header=new Header();
            Thread.Sleep(1000);
            header.GoToMain();
        }
    }
}
