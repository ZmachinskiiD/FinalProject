using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities.Festivalia;
using OpenQA.Selenium;

namespace ATframework3demo.TestCases
{
    public class Case_Mobile_Participation : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
                        {
                            //new TestCase("Mobile: Добавление фестиваль в участвую через поиск фестивалей не авторизованным пользователем", homePage => SearchFestivalOnName(homePage)),
                            new TestCase("Mobile: Удаление из участвую при переносе фестиваля в черновик", homePage => DeleteParticipationUnPublishedFestival(homePage)),
                        };
        }

        private void DeleteParticipationUnPublishedFestival(SearchPage homePage)
        {
            WebItem.DefaultDriver.Manage().Window.Size = new System.Drawing.Size(375,667);
            WebItem.DefaultDriver.Manage().Window.Position = new System.Drawing.Point(630, 200);
            var userDriver = WebItem.DefaultDriver;
            var winHandle = WebItem.DefaultDriver.CurrentWindowHandle;
            

     
            User testUser = new User(true);
            User.CreateUser(testUser);
            User testOrg = new User(true);
            User.CreateUser(testOrg);
            Tag tag = new Tag("", homePage.PortalInfo);
            tag.InsertTag();
            Festival festival = new Festival(1, 2, "", homePage.PortalInfo);
            festival.InsertInBD(testOrg);
            festival.addTags(tag);
            Venue venue = new Venue("", "", "", "", homePage.PortalInfo);
            Event testEvent = new Event(1, 1, 6, 7, "", "", "", homePage.PortalInfo);
            festival.addVenue(venue);
            venue.AddEvent(testEvent);
            testEvent.AddPhotoEvent();
            venue.AddPhotoVenue();
            festival.AddPhotoFestival();

            var addToParticipationFest = homePage
                .GoToHeaderMobile()
                .GoToLogin()
                .Login(testUser)
                .GoToSearch()
                .GoToHeaderMobile()
                .FilterByName(festival.Name)
                .OpenFilterForm()
                .ChooseTag(tag.Name)
                .ApplyChangesAndCloseFilter()
                .GetFestivalPosterByName(festival.Name)
                .AddToParticipationAuth()
                .GoToSearch()
                .GoToHeaderMobile()
                .GoToLK()
                .goToParticipationTab()
                .GetParticipationCardByName(festival.Name)
                .assertByName(festival.Name);

            var orgDriver = WebDriverActions.GetNewDriver();
            WebDriverActions.SwitchDefaultDriver(orgDriver);
            var homePage2 = new SearchPage();
            WebDriverActions.OpenUri(homePage.PortalInfo.PortalUri, orgDriver);
            homePage2
                .GoToHeader()
                .GoToLogin()
                .Login(testOrg)
                .GoToSearch()
                .GoToHeader()
                .GoToLK()
                .GoToMyFestivalsTab()
                .GetFestivalCardByName(festival.Name)
                .OpenMenu()
                .pressTheChangeStatusButton()
                .Publish();



            WebDriverActions.SwitchDefaultDriver(userDriver);
            orgDriver.Quit();
            WebDriverActions.OpenUri(homePage.PortalInfo.PortalUri, homePage.Driver);
            var addAfterUnPibhlished =
            homePage
            .GoToHeaderMobile()
            .GoToLK()
            .goToParticipationTab()
            .GetParticipationCardByName(festival.Name)
            .assertByName(festival.Name);
            if (!addToParticipationFest)
            {
                Log.Error($"Фестиваль {festival.Name} не добавился в участвую");
            }
            if (addAfterUnPibhlished)
            {
                Log.Error($"Фестиваль {festival.Name} Не удалился из участвую после переноса фестиваля в черновик");
            }
        }

        private void SearchFestivalOnName(SearchPage homePage)
        {
            WebItem.DefaultDriver.Manage().Window.Size = new System.Drawing.Size(375, 667);
            User testUser = new User(true);
            User.CreateUser(testUser);
            Tag tag = new Tag("", homePage.PortalInfo);
            tag.InsertTag();
            Festival festival = new Festival(1, 2, "", homePage.PortalInfo);
            festival.InsertInBD(testUser);
            festival.addTags(tag);
            Venue venue = new Venue("", "", "", "", homePage.PortalInfo);
            Event testEvent = new Event(1, 1, 6, 7, "", "", "", homePage.PortalInfo);
            festival.addVenue(venue);
            venue.AddEvent(testEvent);
            testEvent.AddPhotoEvent();
            venue.AddPhotoVenue();
            festival.AddPhotoFestival();
            var result = homePage
                .GoToHeaderMobile()
                .FilterByName(festival.Name)
                .GetFestivalPosterByName(festival.Name)
                .AddToParticipationUnAuth()
                .Login(testUser)
                .GoToSearch()
                .GoToHeaderMobile()
                .GoToLK()
                .goToParticipationTab()
                .GetParticipationCardByName(festival.Name)
                .assertByName(festival.Name);
                
                //.goToFavoriteTab()
                //.GetFavoriteCard(festival.Name)
                //.asserByName(festival.Name);
            if (!result)
            {
                Log.Error($"не найдена карточка фестиваля в участвую с названием {festival.Name}");
            }
        }
    }
}
