using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
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
                new TestCase("Создание аккаунта организатора", homePage => CreateAccount(homePage)),
                new TestCase("Создание аккаунта с существующим email", homePage => CreateAccountWithExistEmail(homePage)),

            };
        }

        private void CreateAccountWithExistEmail(SearchPage homePage)
        {
            User testUser = new User(false);
            testUser.LoginAkaEmail = User.GetRegisteredEmail(homePage.PortalInfo.PortalUri, homePage.PortalInfo.PortalAdmin);
            bool errorCreateAccount = homePage
                .GoToHeader()
                .GoToLogin()
                .GoToRegister()
                .CompleteForm(testUser)
                .CreateAccount(testUser)
                .EmailIsExist();
            if (!errorCreateAccount)
            {
                Log.Error($"не появилось окно с ошибкой {testUser.LoginAkaEmail} уже зарегестрирован в системе");
            } else
            {
                Log.Info($"Появилось окно с ошибкой {testUser.LoginAkaEmail} уже зарегестрирован в системе");
            }
        }
        public static void CreateAccount(SearchPage homePage)
        {     
            User testUser = new User(true);
            var result = homePage
                .GoToHeader()
                .GoToLogin()
                .GoToRegister()
                .CompleteForm(testUser)
                .CreateAccount(testUser)
                .GoToLogin()
                .Login(testUser)
                .GoToSearch()
                .GoToHeader()
                .GoToLK()
                .goToMyDataTab()
                .EmailIsDisplayed(testUser.LoginAkaEmail);
            if (!result)
            {
                Log.Error($"Не отображается email: {testUser.LoginAkaEmail} в личном кабинете");
            }

        }

    }
}
