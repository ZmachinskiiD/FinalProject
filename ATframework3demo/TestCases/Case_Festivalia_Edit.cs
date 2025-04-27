using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities.Festivalia;

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
                            new TestCase("Редактирование основной информации о фестивале", homePage => EditMainInfo(homePage)),
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

                var festivalNewInfo = new Festival(tag, 11, 40, null, homePage.PortalInfo);
                homePage.GoToHeader().GoToLogin().Login(testUser).GoToSearch().GoToHeader().GoToLK().GoToMyFestivalsTab().GetFestivalCardByName(festival.Name)
                    .OpenMenu().OpenFestivalForEdit().ClearData().PassData(festivalNewInfo).SaveData();
                homePage.GoToHeader().FilterByName(festivalNewInfo.Name).goToFestivalPage(festId).assertDescription(festivalNewInfo.Description);

            }
        }
    }
}