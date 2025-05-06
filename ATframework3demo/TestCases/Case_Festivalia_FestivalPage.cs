using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities.Festivalia;

namespace ATframework3demo.TestCases
{
        public class Case_Festivaliya_FestivalPage : CaseCollectionBuilder
        {
            protected override List<TestCase> GetCases()
            {
                return new List<TestCase>
                        {
                            new TestCase("Переход на страницу фестиваля - Змачинский", homePage => GoToFestival(homePage)),
                             new TestCase("Переход на страницу площадки - Змачинский", homePage => GoToVenuePage(homePage)),
                        };
            }
            public static void GoToFestival(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Автомобили", homePage.PortalInfo);
                var festival = new Festival(11, 40,null,homePage.PortalInfo);
                var venue = new Venue(null,null,null,null,homePage.PortalInfo);
                var EEvent = new Event(13, 13);

                var festId=festival.InsertInDB(testUser);
                festival.addTagByName(tag.Name);
                var venueId=festival.addVenue(venue);
                var eventId=venue.AddEvent(EEvent);
                Festival.addPhotos(festId, venueId, eventId, homePage.PortalInfo.PortalUri, homePage.PortalInfo.PortalAdmin);
                homePage.GoToHeader().FilterByName(festival.Name).goToFestivalPage(festId).assertTitle(festival.Name);
                var festivalPage = new FestivalDetailPage();
                festivalPage.assertDescription(festival.Description);

            }
            public static void GoToVenuePage(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Автомобили", homePage.PortalInfo);
                var festival = new Festival(11, 40, null, homePage.PortalInfo);
                var venue = new Venue(null, null, null, null, homePage.PortalInfo);
                var EEvent = new Event(13, 13);

                var festId = festival.InsertInDB(testUser);
                festival.addTagByName(tag.Name);
                var venueId = festival.addVenue(venue);
                var eventId = venue.AddEvent(EEvent);

                Festival.addPhotos(festId, venueId, eventId, homePage.PortalInfo.PortalUri, homePage.PortalInfo.PortalAdmin);
                homePage.GoToHeader().FilterByName(festival.Name).goToFestivalPage(festId).GetVenueByName(venue.Name).GoToVenueDetail().assertTitle(venue.Name);
                var venuePage = new VenueDetailPage();
                venuePage.assertDescription(venue.Description);
            }
        }
   
}
