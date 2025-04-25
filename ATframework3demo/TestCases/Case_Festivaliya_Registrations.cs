using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities.Festivalia;

namespace ATframework3demo.TestCases
{
    public class Case_Festivaliya_Registrations : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
            {
                new TestCase("Создание аккаунта", homePage => CreateAccount(homePage)),
                new TestCase("Болванка", homePage => TestMethod(homePage)),

            };
        }

        private void TestMethod(SearchPage homePage)
        {
            var testUser = new User();
            homePage.GoToHeader().GoToLogin().Login(testUser);
        }

        public static void CreateAccount(SearchPage homePage)
        {
            var epochTime = new DateTime(1, 1, 1, 0, 0, 0);

            string unEmail = (DateTime.Now - epochTime).TotalSeconds.ToString().Replace(',', '1') + "@mail.ru";
            User testUser = new User(true);
            homePage
                .GoToHeader()
                .GoToLogin()
                .GoToRegister()
                .CompleteForm(testUser)
                .CreateAccount();

        }

    }
}
