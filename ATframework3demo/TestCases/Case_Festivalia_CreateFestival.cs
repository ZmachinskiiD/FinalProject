using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.Constructor;
using ATframework3demo.TestEntities.Festivalia;
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

            };
            }

            public static void CreateFestival(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                homePage.GoToHeader().GoToLogin().Login(testUser);

                var name = "Название" + HelperMethods.GetDateTimeSaltString(true, 4);
                var shortdesc = "Краткое" + HelperMethods.GetDateTimeSaltString(true, 4);
                var description = "Полное Описание " + HelperMethods.GetDateTimeSaltString(true, 21);
                var dateStart = HelperMethods.GetDate();
                var dateEnd = HelperMethods.GetDate();
                var timeStart = HelperMethods.GetTimeOfFestival(7);
                var timeEnd = HelperMethods.GetTimeOfFestival(10);

                var festival = new Festival(name, shortdesc, @"C:\\Users\\Admin\\Pictures\\Важные фотки\\_3_2025___1.png.webp", description, dateStart, dateEnd, "Музыка", "\"C:\\Users\\Admin\\Pictures\\Важные фотки\\_3_2025___1.png.webp\"");
                var venue = new Venue(name, shortdesc, @"C:\\Users\\Admin\\Pictures\\Важные фотки\\_3_2025___1.png.webp", description);
                var EEvent = new Event(name, @"C:\\Users\\Admin\\Pictures\\Важные фотки\\_3_2025___1.png.webp", description, dateStart, dateEnd, timeStart, timeEnd);
                var header = new HeaderPage();
                header.GoToLK().GoToMyFestivalsTab().
                    GoToConstructor().
                    PassData(festival)
                   .SelectTag(festival.Tag)
                   .SaveData();
                var upperTab = new ConstructorUpperTab();
                upperTab.
                    goToVenuePage().
                    OpenVenueForm().
                    passData(venue).
                    saveChanges();
                upperTab.goToEventPage().OpenEventFormForVenueByName(venue.Name).passData(EEvent).saveChanges();
                upperTab.goTomapPage().publishFestival().Publish().
                    //FindTheFestival(festival.Name);
                    GoToHeader().GoToLK().GoToMyFestivalsTab().GetFestivalCardByName(festival.Name).FindTheFestival();


            }
            public static void CreateFestivalDraft(SearchPage homePage)
            {
                var name = "Название" + HelperMethods.GetDateTimeSaltString(true, 4);
                var shortdesc = "Краткое" + HelperMethods.GetDateTimeSaltString(true, 4);
                var description = "Полное Описание " + HelperMethods.GetDateTimeSaltString(true, 21);
                var dateStart = HelperMethods.GetDate();
                var dateEnd = HelperMethods.GetDate();
                var photoPath = @"C:\\Users\\Admin\\source\\repos\\FinalProject\\ATlearning\\ATframework3demo\\TestData\\festivalCover.webp";
                var festival = new Festival(name, shortdesc, photoPath, description, dateStart, dateEnd, "Музыка",null);
                homePage.GoToHeader().GoToLK().GoToMyFestivalsTab().
                    GoToConstructor().
                    PassData(festival)
                   .SelectTag(festival.Tag)
                   .SaveData();
                var header = new HeaderPage();
                Console.WriteLine(festival.Name);
                header.GoToSearch().GoToHeader().
                    GoToLK().GoToMyFestivalsTab().GoToDrafts().GetFestivalCardByName(festival.Name).FindTheFestival();

            }
            public static void CreateDateStartBiggerthanDateEnd(SearchPage homePage)
            {
                var name = "Название" + HelperMethods.GetDateTimeSaltString(true, 4);
                var shortdesc = "Краткое" + HelperMethods.GetDateTimeSaltString(true, 4);
                var description = "Полное Описание " + HelperMethods.GetDateTimeSaltString(true, 21);
                var dateStart = HelperMethods.GetDate(2);
                var dateEnd = HelperMethods.GetDate(1);
                var photoPath = @"C:\\Users\\Admin\\source\\repos\\FinalProject\\ATlearning\\ATframework3demo\\TestData\\festivalCover.webp";
                var festival = new Festival(name, shortdesc, photoPath, description, dateStart, dateEnd, "Музыка", null);
                homePage.GoToHeader().GoToLK().GoToMyFestivalsTab().
                    GoToConstructor().
                    PassData(festival).AssertIncorrectStartEndDate();


            }
        }
    }
}
