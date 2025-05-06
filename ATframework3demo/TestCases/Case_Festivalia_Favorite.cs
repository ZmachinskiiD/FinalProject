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
                            new TestCase("Добавление фестиваль в избранное с последующей авторизацией", homePage => AddFavoriteUnAuthUser(homePage)),
                            new TestCase("Удаление из избранного при переносе фестиваля в черновик", homePage => DeleteFavoriteUnPublishedFestival(homePage)),
                        };
        }

        private void DeleteFavoriteUnPublishedFestival(SearchPage homePage)
        {
            User testUser = new User(true);
            User.CreateUser(testUser);
            Tag tag = new Tag(portalInfo: homePage.PortalInfo);
            Festival festival = new Festival(1, 2, portalInfo: homePage.PortalInfo);
            Venue venue = new Venue(portalInfo: homePage.PortalInfo);
            Event testEvent = new Event(1, 1, 6, 7, portalInfo: homePage.PortalInfo);
            
            festival.AddTestDataFest(testUser, tag, venue, testEvent);

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

        private void AddFavoriteUnAuthUser(SearchPage homePage)
        {
            User testUser = new User(true);
            User.CreateUser(testUser);
            Tag tag = new Tag(portalInfo: homePage.PortalInfo);
            Venue venue = new Venue(portalInfo: homePage.PortalInfo);
            Event testEvent = new Event(1, 1, 6, 7, portalInfo: homePage.PortalInfo);
            Festival festival = new Festival(1, 2, portalInfo: homePage.PortalInfo);
            festival.AddTestDataFest(testUser, tag, venue, testEvent);
    
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
