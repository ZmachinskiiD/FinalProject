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

            };
            }

            public static void CreateFestival(SearchPage homePage)
            {
                var name = "Название" + HelperMethods.GetDateTimeSaltString(true, 4);
                var shortdesc="Краткое" + HelperMethods.GetDateTimeSaltString(true, 4);
                var description = "Полное Описание " + HelperMethods.GetDateTimeSaltString(true, 21);
                var dateStart = HelperMethods.getDate();
                var dateEnd = HelperMethods.getDate();
                var timeStart = HelperMethods.getTimeOfFestival(7);
                var timeEnd = HelperMethods.getTimeOfFestival(10);

                var festival = new Festival(name, shortdesc, @"C:\\Users\\Admin\\Pictures\\Важные фотки\\_3_2025___1.png.webp", description, dateStart, dateEnd, "Музыка", "\"C:\\Users\\Admin\\Pictures\\Важные фотки\\_3_2025___1.png.webp\"");
                var venue = new Venue(name, shortdesc, @"C:\\Users\\Admin\\Pictures\\Важные фотки\\_3_2025___1.png.webp", description);
                var EEvent = new Event(name, @"C:\\Users\\Admin\\Pictures\\Важные фотки\\_3_2025___1.png.webp", description, dateStart, dateEnd, timeStart, timeEnd);
                var header = new HeaderPage();
                header.GoToLK().goToMyFestivalsTab().
                    goToConstructor().
                    passData(festival)
                   .selectTag(festival.Tag)
                   .saveData();
                var upperTab = new ConstructorUpperTab();
                upperTab.
                    goToVenuePage().
                    OpenVenueForm().
                    passData(venue).
                    saveChanges();
                upperTab.goToEventPage().OpenEventFormForVenueByName(venue.Name).passData(EEvent).saveChanges();
                upperTab.goTomapPage().publishFestival().Publish().
                    //findTheFestival(festival.Name);
                    GoToHeader().GoToLK().goToMyFestivalsTab().getFestivalCardByName(festival.Name).findTheFestival();


            }
        }
    }
}
