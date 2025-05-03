using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities.Festivalia;

namespace ATframework3demo.TestCases
{
    public class CaseFestivalya_LK : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
            {
                new TestCase("Отсутствие таба Мои фестивали у посетителя - Змачинский", homePage => ValidateVisitortabs(homePage)),
                new TestCase("Публикация фестиваля без события - Змачинский", homePage => publishFestivalWithoutEvents(homePage)),
                new TestCase("Публикация фестиваля без площадок - Змачинский", homePage => publishFestivalWithoutVenues(homePage)),
                new TestCase("Перенос фестиваля в черновики - Змачинский", homePage => makeFestivalADraft(homePage)),
                new TestCase("Публикация фестиваля - Змачинский", homePage => PublishFestival(homePage)),

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
        private void publishFestivalWithoutEvents(SearchPage homePage)
        {
            var testUser = new User(true);
            User.CreateUser(testUser);
            var tag = new Tag("Активный отдых", homePage.PortalInfo);
            var festival = new Festival(11, 40, null, homePage.PortalInfo);
            var venue = new Venue(null, null, null, null, homePage.PortalInfo);
            var festId = festival.insertFestival(testUser, false);
            festival.addTagByName(tag.Name);
            var venueId = festival.addVenue(venue);
            festival.AddPhotoFestival();
            venue.AddPhotoVenue();
            homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().GoToDrafts().GetFestivalCardByName(festival.Name)
                   .OpenMenu().pressTheChangeStatusButton().AssertCantPublishWithoutEvent();
            var header = new HeaderPage();
            header.FilterByName(festival.Name).assertFestivalDoesntExistOnMain(festival.Name);

        }
        private void publishFestivalWithoutVenues(SearchPage homePage)
        {
            var testUser = new User(true);
            User.CreateUser(testUser);
            var tag = new Tag("Активный отдых", homePage.PortalInfo);
            var festival = new Festival(11, 40, null, homePage.PortalInfo);
 
            var festId = festival.insertFestival(testUser, false);
            festival.addTagByName(tag.Name);
            festival.AddPhotoFestival();
            homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().GoToDrafts().GetFestivalCardByName(festival.Name)
                   .OpenMenu().pressTheChangeStatusButton().AssertCantPublishWithoutVenue();
            var header = new HeaderPage();
            header.FilterByName(festival.Name).assertFestivalDoesntExistOnMain(festival.Name);

        }
        public static void makeFestivalADraft(SearchPage homePage)
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
            Festival.addPhotos(festId, venueId, eventId, homePage.PortalInfo.PortalUri, homePage.PortalInfo.PortalAdmin);
            homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().GetFestivalCardByName(festival.Name)
               .OpenMenu().pressTheChangeStatusButton().ToDrafts();
            var header = new HeaderPage();
            header.FilterByName(festival.Name).assertFestivalDoesntExistOnMain(festival.Name);
        }
        public static void PublishFestival(SearchPage homePage)
        {
            var testUser = new User(true);
            User.CreateUser(testUser);
            var tag = new Tag("Активный отдых", homePage.PortalInfo);
            var festival = new Festival(11, 40, null, homePage.PortalInfo);
            var venue = new Venue(null, null, null, null, homePage.PortalInfo);
            var EEvent = new Event(13, 13);
            var festId = festival.insertFestival(testUser, false);
            festival.addTagByName(tag.Name);
            var venueId = festival.addVenue(venue);
            var eventId = venue.AddEvent(EEvent);
            Festival.addPhotos(festId, venueId, eventId, homePage.PortalInfo.PortalUri, homePage.PortalInfo.PortalAdmin);
            homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().GoToDrafts().GetFestivalCardByName(festival.Name)
               .OpenMenu().pressTheChangeStatusButton().Publish();
            var header = new HeaderPage();
            header.FilterByName(festival.Name).findTheFestival(festival.Name);
        }
    }
}
