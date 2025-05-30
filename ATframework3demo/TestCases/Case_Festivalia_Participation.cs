﻿using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities.Festivalia;
using OpenQA.Selenium;

namespace ATframework3demo.TestCases
{
    public class Case_Festivalia_Participation : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
                        {
                            new TestCase("Добавление фестиваль в участвую с последующей авторизацией", homePage => AddToPartipicationUnAuthUser(homePage)),
                            new TestCase("Удаление из участвую при переносе фестиваля в черновик", homePage => DeleteParticipationUnPublishedFestival(homePage)),
                        };
        }

        private void DeleteParticipationUnPublishedFestival(SearchPage homePage)
        {
            User testUser = new User(true);
            User.CreateUser(testUser);
            Tag tag = new Tag("", homePage.PortalInfo);
            tag.InsertTag();
            Festival festival = new Festival(1, 2, "", homePage.PortalInfo);
            festival.InsertInDB(testUser);
            festival.addTags(tag);
            Venue venue = new Venue("", "", "", "", homePage.PortalInfo);
            Event testEvent = new Event(1, 1, 6, 7, "", "", "", homePage.PortalInfo);
            festival.addVenue(venue);
            venue.AddEvent(testEvent);
            testEvent.AddPhotoEvent();
            venue.AddPhotoVenue();
            festival.AddPhotoFestival();
            var addToParticipationFest = homePage
                .GoToHeader()
                .GoToLogin()
                .Login(testUser)
                .GoToSearch()
                .GoToHeader()
                .FilterByName(festival.Name)
                .GetFestivalPosterByName(festival.Name)
                .AddToParticipationAuth()
                .GoToSearch()
                .GoToHeader()
                .GoToLK()
                .goToParticipationTab()
                .GetParticipationCardByName(festival.Name)
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

        private void AddToPartipicationUnAuthUser(SearchPage homePage)
        {
            User testUser = new User(true);
            User.CreateUser(testUser);
            Tag tag = new Tag("", homePage.PortalInfo);
            tag.InsertTag();
            Festival festival = new Festival(1, 2, "", homePage.PortalInfo);
            festival.InsertInDB(testUser);
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
                .AddToParticipationUnAuth()
                .Login(testUser)
                .GoToSearch()
                .GoToHeader()
                .GoToLK()
                .goToParticipationTab()
                .GetParticipationCardByName(festival.Name)
                .assertByName(festival.Name);

            if (!result)
            {
                Log.Error($"не найдена карточка фестиваля в участвую с названием {festival.Name}");
            }
        }
    }
}
