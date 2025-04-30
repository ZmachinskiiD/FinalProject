using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities.Festivalia;

namespace ATframework3demo.TestCases
{
    public class Case_Festivalia_SearchFestival : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
                        {
                            new TestCase("Поиск фестиваля по названию фестиваля", homePage => SearchFestivalOnName(homePage)),
                            new TestCase("Поиск фестиваля по тегу", homePage => SearchFestivalOnTag(homePage)),
                            new TestCase("Поиск фестиваля по нескольким тегам", homePage => SearchFestivalOnTags(homePage)),
                            new TestCase("Поиск фестиваля по названию без учета регистра", homePage => SearchFestivalUnRegistred(homePage)),
                            new TestCase("Переход на детальную карточку найденного фестиваля", homePage => OpenDetailFestivalOnName(homePage)),
                        };
        }

        private void OpenDetailFestivalOnName(SearchPage homePage)
        {
            User testUser = new User(true);
            User.CreateUser(testUser);
            Tag tag = new Tag("Музыка", homePage.PortalInfo);
            Festival festival = new Festival(0, 0, "", homePage.PortalInfo);
            festival.insertFestival(testUser);
            festival.addTags(tag);
            Venue venue = new Venue("", "", "", "", homePage.PortalInfo);
            Event testEvent = new Event(0, 0, 6, 7, "", "", "", homePage.PortalInfo);
            festival.addVenue(venue);
            venue.AddEvent(testEvent);
            testEvent.AddPhotoEvent();
            venue.AddPhotoVenue();
            festival.AddPhotoFestival();
            homePage
                .GoToHeader()
                .FilterByName(festival.Name)
                .GetFestivalPosterByName(festival.Name)
                .OpenDetailPage()
                .assertTitle(festival.Name);
        }

        private void SearchFestivalUnRegistred(SearchPage homePage)
        {
            User testUser = new User(true);
            User.CreateUser(testUser);
            Tag tag = new Tag("Музыка", homePage.PortalInfo);
            Festival festival = new Festival(0, 0, "", homePage.PortalInfo);
            festival.Name = festival.Name.ToUpper();
            festival.insertFestival(testUser);
            festival.addTags(tag);
            Venue venue = new Venue("", "", "", "", homePage.PortalInfo);
            Event testEvent = new Event(0, 0, 6, 7, "", "", "", homePage.PortalInfo);
            festival.addVenue(venue);
            venue.AddEvent(testEvent);
            testEvent.AddPhotoEvent();
            venue.AddPhotoVenue();
            festival.AddPhotoFestival();
            homePage
                .GoToHeader()
                .FilterByName(festival.Name.ToLower());

            var result = homePage
                .GetFestivalPosterByName(festival.Name)
                .assertNameCard(festival.Name);

            if (!result)
            {
                Log.Error($"Не появилась афиша фестиваля с именем {festival.Name} и поиску строки {festival.Name.ToLower()}");
            }
        }

        private void SearchFestivalOnTags(SearchPage homePage)
        {
            User testUser = new User(true);
            Console.WriteLine(testUser.LoginAkaEmail);
            User.CreateUser(testUser);
            Tag tag1 = new Tag("", homePage.PortalInfo);
            tag1.InsertTag();
            Tag tag2 = new Tag("", homePage.PortalInfo);
            tag2.InsertTag();
            Tag tag3 = new Tag("", homePage.PortalInfo);
            tag3.InsertTag();
            Festival festival = new Festival(0, 0, "", homePage.PortalInfo);
            festival.insertFestival(testUser);
            festival.addTags(tag1);
            festival.addTags(tag2);
            festival.addTags(tag3);
            Venue venue = new Venue("", "", "", "", homePage.PortalInfo);
            Event testEvent = new Event(0, 0, 6, 7, "", "", "", homePage.PortalInfo);
            festival.addVenue(venue);
            venue.AddEvent(testEvent);
            testEvent.AddPhotoEvent();
            venue.AddPhotoVenue();
            festival.AddPhotoFestival();
            WebDriverActions.Refresh();
            homePage
                .OpenFilterForm()
                .ChooseTag(tag1.Name)
                .ChooseTag(tag2.Name)
                .ChooseTag(tag3.Name)
                .ApplyChangesAndCloseFilter();

            var result = homePage
                .GetFestivalPosterByName(festival.Name)
                .assertNameCard(festival.Name);

            if (!result)
            {
                Log.Error($"Не появилась афиша фестиваля по тегу {tag1.Name},{tag2.Name},{tag3.Name} и именем {festival.Name}");
            }
        }

        private void SearchFestivalOnTag(SearchPage homePage)
        {
            User testUser = new User(true);
            Console.WriteLine(testUser.LoginAkaEmail);
            User.CreateUser(testUser);
            Tag tag = new Tag("", homePage.PortalInfo);
            tag.InsertTag();
            Festival festival = new Festival(0, 0, "", homePage.PortalInfo);
            festival.insertFestival(testUser);
            festival.addTags(tag);
            Venue venue = new Venue("", "", "", "", homePage.PortalInfo);
            Event testEvent = new Event(0, 0, 6, 7, "", "", "", homePage.PortalInfo);
            festival.addVenue(venue);
            venue.AddEvent(testEvent);
            testEvent.AddPhotoEvent();
            venue.AddPhotoVenue();
            festival.AddPhotoFestival();
            WebDriverActions.Refresh();
            homePage
                .OpenFilterForm()
                .ChooseTag(tag.Name)
                .ApplyChangesAndCloseFilter();

            var result = homePage
                .GetFestivalPosterByName(festival.Name)
                .assertNameCard(festival.Name);

            if (!result)
            {
                Log.Error($"Не появилась афиша фестиваля по тегу {tag.Name} и именем {festival.Name}");
            } 
        }

        private void SearchFestivalOnName(SearchPage homePage)
        {
            User testUser = new User(true);
            Console.WriteLine(testUser.LoginAkaEmail);
            User.CreateUser(testUser);
            Tag tag = new Tag("Музыка",homePage.PortalInfo);
            Festival festival = new Festival(0,0,"",homePage.PortalInfo);
            festival.insertFestival(testUser);
            festival.addTags(tag);
            Venue venue = new Venue("","","","",homePage.PortalInfo);
            Event testEvent = new Event(0,0,6,7,"","","",homePage.PortalInfo);
            festival.addVenue(venue);
            venue.AddEvent(testEvent);
            testEvent.AddPhotoEvent();
            venue.AddPhotoVenue();
            festival.AddPhotoFestival();
            homePage
                .GoToHeader()
                .FilterByName(festival.Name);

            var result = homePage
                .GetFestivalPosterByName(festival.Name)
                .assertNameCard(festival.Name);
            
            if (!result)
            {
                Log.Error($"Не появилась афиша фестиваля с именем {festival.Name}");
            }
                
                

        }
    }
}
