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
                new TestCase("Создание аккаунта", homePage => CreateAccount(homePage), false),

            };
        }

        public static void CreateAccount(SearchPage homePage)
        {
            User testUser = new User("ptichka@mail.ru", true);
            homePage
                .GoToHeader()
                .GoToLogin()
                .GoToRegister()
                .CompleteForm(testUser)
                .CreateAccount();

        }
    }
}
