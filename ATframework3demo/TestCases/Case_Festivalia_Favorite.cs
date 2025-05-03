using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities.Festivalia;

namespace ATframework3demo.TestCases
{
    public class Case_Festivalia_Favorite : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
                        {
                            new TestCase("Добавление фестиваль в избранное через поиск фестивалей не авторизованным пользователем", homePage => AddFavoriteInSearch(homePage)),
                            new TestCase("Удаление из избранного при переносе фестиваля в черновик", homePage => DeleteFavoriteUnPublishedFestival(homePage)),
                        };
        }

        private void DeleteFavoriteUnPublishedFestival(SearchPage homePage)
        {
            User testUser = new User(true);
            User.CreateUser(testUser);
            Tag tag = new Tag("",homePage.PortalInfo);
            tag.InsertTag();
            Festival festival = new Festival(1, 2, "", homePage.PortalInfo);
            festival.insertFestival(testUser);
            festival.addTags(tag);
            Venue venue = new Venue("", "", "", "", homePage.PortalInfo);
            Event testEvent = new Event(1, 1, 6, 7, "", "", "", homePage.PortalInfo);
            festival.addVenue(venue);
            venue.AddEvent(testEvent);
            testEvent.AddPhotoEvent();
            venue.AddPhotoVenue();
            festival.AddPhotoFestival();
            var addToFavoriteFest = homePage
                .GoToHeader()
                .GoToLogin()
                .Login(testUser)
                .GoToSearch()
                .GoToHeader()
                .FilterByName(festival.Name)
                .GetFestivalPosterByName(festival.Name)
                .AddToFavoriteAuth()
                .GoToSearch()
                .GoToHeader()
                .GoToLK()
                .goToFavoriteTab()
                .GetFavoriteCard(festival.Name)
                .assertByName(festival.Name);
            WebDriverActions.OpenUri(homePage.PortalInfo.PortalUri, homePage.Driver);
            homePage
                .GoToHeader()
                .GoToLK()
                .GoToMyFestivalsTab()
                .GetFestivalCardByName(festival.Name)
                .OpenMenu()
                .pressTheChangeStatusButton()
                .ToDrafts();
            WebDriverActions.OpenUri(homePage.PortalInfo.PortalUri, homePage.Driver);
                var addAfterUnPibhlished =
                homePage
                .GoToHeader()
                .GoToLK()
                .goToFavoriteTab()
                .GetFavoriteCard(festival.Name)
                .assertByName(festival.Name);
                if (!addToFavoriteFest)
            {
                Log.Error($"Фестиваль {festival.Name} не добавился в избранное");
            }
                if (addAfterUnPibhlished)
            {
                Log.Error($"Фестиваль {festival.Name} Не удалился из избранного после переноса фестиваля в черновик");
            }
            
                

        }

        private void AddFavoriteInSearch(SearchPage homePage)
        {
            User testUser = new User(true);
            User.CreateUser(testUser);
            Tag tag = new Tag("", homePage.PortalInfo);
            tag.InsertTag();
            Festival festival = new Festival(1, 2, "", homePage.PortalInfo);
            festival.insertFestival(testUser);
            festival.addTags(tag);
            Venue venue = new Venue("", "", "", "", homePage.PortalInfo);
            Event testEvent = new Event(1, 1, 6, 7, "", "", "", homePage.PortalInfo);
            festival.addVenue(venue);
            venue.AddEvent(testEvent);
            testEvent.AddPhotoEvent();
            venue.AddPhotoVenue();
            festival.AddPhotoFestival();
            var result = homePage
                .GoToHeader()
                .FilterByName(festival.Name)
                .GetFestivalPosterByName(festival.Name)
                .AddToFavoriteUnAuth()
                .Login(testUser)
                .GoToSearch()
                .GoToHeader()
                .GoToLK()
                .goToFavoriteTab()
                .GetFavoriteCard(festival.Name)
                .assertByName(festival.Name);
            if (!result)
            {
                Log.Error($"не найдена карточка фестиваля в избранном с названием {festival.Name}");
            }

        }
    }
}
