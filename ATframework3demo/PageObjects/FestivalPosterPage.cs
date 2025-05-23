﻿using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class FestivalPosterPage
    {
        public FestivalPosterPage(string path, IWebDriver driver = default)
        {
            Driver = driver;
            Path = path;
        }
        public IWebDriver Driver { get; }
        public string Path { get; }
        WebItem likeBtn =>
            new WebItem(Path + "//button[contains(@class,'action-btn favorite')]",
                "Кнопка добавить в ибзранное по названию фестиваля");
        WebItem participatingBtn =>
           new WebItem(Path + "//button[contains(@class,'action-btn participate')]",
               "Кнопка добавить участвую по названию фестиваля");
        WebItem detailBtn =>
            new WebItem(Path + "//a[contains(@class,'details-btn')]",
                $"Кнопка подробнее о фестивале по названию");
        WebItem nameFestival(string name) =>
            new WebItem(Path + $"//h3[text()='{name}']",
                "Название фестиваля в афише фестиваля");

        public SearchPage GoToSearch()
        {
            return new SearchPage();
        }
        public bool assertNameCard(string name)
        {
            return nameFestival(name).WaitElementDisplayed(3);
        }
        public FestivalDetailPage OpenDetailPage()
        {
            detailBtn.Hover();
            detailBtn.Click();
            return new FestivalDetailPage();
        }

        public FestivalPosterPage AddToFavoriteAuth()
        {
            likeBtn.Hover();
            likeBtn.Click();
            return new FestivalPosterPage(Path);
        }
        public LoginPage AddToFavoriteUnAuth()
        {
            likeBtn.Hover();
            likeBtn.Click();
            return new LoginPage();
        }
        public FestivalPosterPage AddToParticipationAuth()
        {
            participatingBtn.Hover();
            participatingBtn.Click();
            return new FestivalPosterPage(Path);
        }
        public LoginPage AddToParticipationUnAuth()
        {
            participatingBtn.Hover();
            participatingBtn.Click();
            return new LoginPage();
        }

    }
}
