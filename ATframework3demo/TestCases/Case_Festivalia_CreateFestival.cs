using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.Constructor;
using ATframework3demo.TestEntities.Festivalia;
using System.Xml.Linq;
// @"C:\\Users\\Admin\\Downloads\\График_сменности.docx"
namespace ATframework3demo.TestCases
{
    public class Case_Festivalia_CreateFestival
    {
        public class Case_Festivaliya_CreateFestival : CaseCollectionBuilder
        {
            protected override List<TestCase> GetCases()
            {
                return new List<TestCase>
            {
                new TestCase("Создание фестиваля", homePage => CreateFestival(homePage)),
                new TestCase("Создание черновика фестиваля", homePage => CreateFestivalDraft(homePage)),
                new TestCase("Создание фестиваля c датой начала больше даты конца", homePage => CreateDateStartBiggerthanDateEnd(homePage)),
                //new TestCase("Создание фестиваля c датой начала меньше сегодня", homePage => CreateFestivalBeforeToday(homePage)),

            };
            }

            public static void CreateFestival(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Музыка");
                var festival = new Festival(1,4);
                var venue = new Venue();
                var EEvent = new Event(2,3);
                homePage
                    .GoToHeader()
                    .GoToLogin()
                    .Login(testUser)
                    .GoToSearch()
                    .GoToHeader()
                    .GoToLK()
                    .GoToMyFestivalsTab()
                    .GoToConstructor()
                    .PassData(festival)
                    .SelectTag(tag.Name)
                    .SaveData();

                var upperTab = new ConstructorUpperTab();
                upperTab.
                    goToVenuePage().
                    OpenVenueForm().
                    passData(venue).
                    saveChanges();
                upperTab.goToEventPage().OpenEventFormForVenueByName(venue.Name).passData(EEvent).saveChanges();
                upperTab.goTomapPage().publishFestival().ConfirmPublication().
                    //FindTheFestival(festival.Name);
                    GoToHeader().GoToLK().GoToMyFestivalsTab().GetFestivalCardByName(festival.Name).FindTheFestival();
                var header= new HeaderPage();
                header.FilterByName(festival.Name).findTheFestival(festival.Name);
                var festivalPage=homePage.GoToFestivalPageByName(festival.Name);
                festivalPage.assertTitle(festival.Name);
                festivalPage.assertDescription(festival.Description);
                var venuePage = festivalPage.GetVenueByName(venue.Name).GoToVenueDetail();
                venuePage.assertTitle(venue.Name);
                venuePage.assertDescription(venue.Description);
                venuePage.FindEventByName(EEvent.Name).assertDescriptionText(EEvent.Description);


            }
            public static void CreateFestivalDraft(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Музыка");
                var festival = new Festival();
                var venue = new Venue();
                var EEvent = new Event();
                User.CreateUser(testUser);
                homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().
                    GoToConstructor().
                    PassData(festival)
                   .SelectTag(tag.Name)
                   .SaveData();
                var header = new HeaderPage();
                Console.WriteLine(festival.Name);
                header.GoToSearch().GoToHeader().
                    GoToLK().GoToMyFestivalsTab().GoToDrafts().GetFestivalCardByName(festival.Name).FindTheFestival();

            }
            public static void CreateDateStartBiggerthanDateEnd(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Музыка");
                var festival = new Festival(5,2);
                var venue = new Venue();
                var EEvent = new Event();
                homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().
                    GoToConstructor().
                    PassData(festival).AssertIncorrectStartEndDate();


            }
            //Неактуально для текущей версии. Оставлено для возможного дальнейшего тестирования
            public static void CreateFestivalBeforeToday(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Музыка");
                var festival = new Festival(-10,2);
                var venue = new Venue();
                var EEvent = new Event();
                homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().
                    GoToConstructor().
                    PassData(festival).SaveData().AssertStartDateIsIncorrect();
            }
            
        }
    }
}
