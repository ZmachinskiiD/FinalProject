using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities.Festivalia;

namespace ATframework3demo.TestCases
{
    public class Case_Festivalia_FestivalPage
    {
        public class Case_Festivaliya_FestivalPage : CaseCollectionBuilder
        {
            protected override List<TestCase> GetCases()
            {
                return new List<TestCase>
                        {
                            new TestCase("Переход на страницу фестиваля", homePage => GoToFestival(homePage)),
                        };
            }
            public static void GoToFestival(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Активный отдых", homePage.PortalInfo);
                var festival = new Festival(tag, 11, 40,null,homePage.PortalInfo);
                var venue = new Venue(null,null,null,null,homePage.PortalInfo);
                var EEvent = new Event(13, 13);

                var festId=festival.insertFestival(testUser);
                festival.addTagByName(tag.Name);
                var venueId=festival.addVenue(venue);
                var eventId=venue.AddEvent(EEvent);
                Festival.addPhotos(festId, venueId, eventId, 400, homePage.PortalInfo.PortalUri, homePage.PortalInfo.PortalAdmin);
                homePage.GoToHeader().FilterByName(festival.Name).findTheFestival(festId);

            }
        }
    }
}
