using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.Constructor;
using ATframework3demo.TestEntities.Festivalia;
using Microsoft.Extensions.Logging;

namespace ATframework3demo.TestCases
{
    public class Case_Festivalia_Edit
    {
        public class Case_Festivaliya_Edit : CaseCollectionBuilder
        {
            protected override List<TestCase> GetCases()
            {
                return new List<TestCase>
                        {
                            new TestCase("Редактирование основной информации о фестивале - Змачинский", homePage => EditMainInfo(homePage)),
                            new TestCase("Редактирование информации о площадке - Змачинский", homePage => EditVenueInfo(homePage)),
                            new TestCase("Редактирование информации о событии - Змачинский", homePage => EditEventInfo(homePage)),
                             new TestCase("Удаление площадки - Змачинский", homePage => CheckForTheDeletionOfTheVenue(homePage)),
                        };
            }
            public static void EditMainInfo(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Активный отдых", homePage.PortalInfo);
                var festival = new Festival(11, 40, null, homePage.PortalInfo);
                var venue = new Venue(null, null, null, null, homePage.PortalInfo);
                var EEvent = new Event(13, 13);
                var festId = festival.insertFestival(testUser);
                festival.addTagByName(tag.Name);
                var venueId = festival.addVenue(venue);
                var eventId = venue.AddEvent(EEvent);
                Festival.addPhotos(festId, venueId, eventId, 400, homePage.PortalInfo.PortalUri, homePage.PortalInfo.PortalAdmin);

                var festivalNewInfo = new Festival(11, 40, null, homePage.PortalInfo);
                homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().GetFestivalCardByName(festival.Name)
                    .OpenMenu().OpenFestivalForEdit().ClearData().PassData(festivalNewInfo).SaveData();
                var festivalPage = homePage.GoToHeader().FilterByName(festivalNewInfo.Name).goToFestivalPage(festId);
                festivalPage.assertTitle(festivalNewInfo.Name);
                festivalPage.assertDescription(festivalNewInfo.Description);
                festivalPage.AssertDates(festivalNewInfo.DateStart, festivalNewInfo.DateEnd);

            }
            public static void EditVenueInfo(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Активный отдых", homePage.PortalInfo);
                var festival = new Festival(11, 40, null, homePage.PortalInfo);
                var venue = new Venue(null, null, null, null, homePage.PortalInfo);
                var EEvent = new Event(13, 13);
                var festId = festival.insertFestival(testUser);
                festival.addTagByName(tag.Name);
                var venueId = festival.addVenue(venue);
                var eventId = venue.AddEvent(EEvent);
                Festival.addPhotos(festId, venueId, eventId, 400, homePage.PortalInfo.PortalUri, homePage.PortalInfo.PortalAdmin);

                var venue2 = new Venue(null, null, null, null, homePage.PortalInfo);
                homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().GetFestivalCardByName(festival.Name)
                    .OpenMenu().OpenFestivalForEdit();
                var FestivalUpperTab = new ConstructorUpperTab();
                FestivalUpperTab.goToVenuePage().OpenVenueCard(venue.Name).OpenForEdit().clearData().passData(venue2).saveChanges();
                var header = new HeaderPage();
                header.FilterByName(festival.Name).goToFestivalPage(festId).GetVenueByName(venue2.Name).GoToVenueDetail().assertDescription(venue2.Description);
            }
            public static void EditEventInfo(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Активный отдых", homePage.PortalInfo);
                var festival = new Festival(11, 40, null, homePage.PortalInfo);
                var venue = new Venue(null, null, null, null, homePage.PortalInfo);
                var EEvent = new Event(13, 13);
                var festId = festival.insertFestival(testUser);
                festival.addTagByName(tag.Name);
                var venueId = festival.addVenue(venue);
                var eventId = venue.AddEvent(EEvent);
                Festival.addPhotos(festId, venueId, eventId, 400, homePage.PortalInfo.PortalUri, homePage.PortalInfo.PortalAdmin);

                var Event2 = new Event(13, 13);
                homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().GetFestivalCardByName(festival.Name)
                    .OpenMenu().OpenFestivalForEdit();
                var FestivalUpperTab = new ConstructorUpperTab();
                FestivalUpperTab.goToEventPage().OpenEventList(venue.Name).GoToEventCard(EEvent.Name).OpenForEdit().editData(Event2).saveChanges();
                var header = new HeaderPage();
                header.FilterByName(festival.Name).goToFestivalPage(festId).GetVenueByName(venue.Name).GoToVenueDetail().FindEventByName(Event2.Name).assertDescriptionText(Event2.Description);
            }
            public static void CheckForTheDeletionOfTheVenue(SearchPage homePage)
            {
                var testUser = new User(true);
                User.CreateUser(testUser);
                var tag = new Tag("Активный отдых", homePage.PortalInfo);
                var festival = new Festival(11, 40, null, homePage.PortalInfo);
                var venue = new Venue(null, null, null, null, homePage.PortalInfo);
                var venue2 = new Venue("ПЛ2", null, null, null, homePage.PortalInfo);
                var EEvent = new Event(13, 13);
                var festId = festival.insertFestival(testUser);
                festival.addTagByName(tag.Name);
                var venueId = festival.addVenue(venue);
                var venueId2 = festival.addVenue(venue2);
                var eventId = venue.AddEvent(EEvent); 
                Festival.addPhotos(festId, venueId, eventId, 400, homePage.PortalInfo.PortalUri, homePage.PortalInfo.PortalAdmin);
                venue2.AddPhotoVenue();
                homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().GetFestivalCardByName(festival.Name)
                    .OpenMenu().OpenFestivalForEdit();
                var FestivalUpperTab = new ConstructorUpperTab();
                FestivalUpperTab.goToVenuePage().OpenVenueCard(venue2.Name).deleteVenue();
                WebDriverActions.BrowserAlert(true);
                var header = new HeaderPage();
                header.FilterByName(festival.Name).goToFestivalPage(festId).GetVenueByName(venue2.Name).assertVenueDoesntExist();
            }
        }
    }
}