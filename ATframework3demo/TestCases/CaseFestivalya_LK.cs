using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
    public class CaseFestivalya_LK : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
            {
                new TestCase("Отсутствие таба Мои фестивали у посетителя", homePage => ValidateVisitortabs(homePage)),

            };
        }
        private void ValidateVisitortabs(SearchPage homePage)
        {
            User testUser = new User(false);
            homePage
                   .GoToHeader()
                   .GoToLogin()
                   .Login(testUser).GoToSearch()
                    .GoToHeader()
                    .GoToLK().assertMyFestivalTabDoNotExist();
        }
    }
}
