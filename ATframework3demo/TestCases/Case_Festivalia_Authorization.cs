using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Festivalia_Authorization : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
            {
                new TestCase("Авторизация существующего пользователя", homePage => AuthorizationExistUser(homePage)),
                new TestCase("Авторизация с незарегестрированным email", homePage => AuthorizationUnRegEmail(homePage)),


            };
        }

        private void AuthorizationUnRegEmail(SearchPage homePage)
        {
            User testUser = new User();
            var result = homePage
                .GoToHeader()
                .GoToLogin()
                .Login(testUser)
                .ErrorEmailorPwdDisplayed();

            if (!result)
            {
                Log.Error("Не появилась ошибка о неправильно заполненом email или пароле");
            }
                
        }

        private void AuthorizationExistUser(SearchPage homePage)
        {
            User testUser = new User();
            User.CreateUser(testUser);
            var result = homePage
                .GoToHeader()
                .GoToLogin()
                .Login(testUser)
                .GoToSearch()
                .GoToHeader()
                .GoToLK()
                .goToMyDataTab()
                .EmailIsDisplayed(testUser.LoginAkaEmail);

            if (!result)
            {
                Log.Error($"В личном кабинете не отображается email: {testUser.LoginAkaEmail}");
            }
        }
    }
}
