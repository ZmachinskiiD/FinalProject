using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using System.Globalization;

namespace ATframework3demo.TestEntities.Festivalia
{
    public class Festival
    {
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string MapPath { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public PortalInfo PortalInfo { get; }
        public Festival(int dateStartFromToday = 0, int dateEndFromToday = 0, string? mapPath = null, PortalInfo? portalInfo = null)
        {
            PhotoPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..")) + @"\TestData\festivalCover.jpg"; 
            Name = "Название" + HelperMethods.GetDateTimeSaltString(true, 10);
            ShortDescription = "Краткое" + HelperMethods.GetDateTimeSaltString(true, 10);
            Description = "Полное Описание " + HelperMethods.GetDateTimeSaltString(true, 21);
            DateStart = HelperMethods.GetDate(dateStartFromToday);
            DateEnd = HelperMethods.GetDate(dateEndFromToday);
            MapPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..")) + @"\TestData\Карта.jpeg";
            PortalInfo = portalInfo;

        }

        public string insertFestival(User user)
        {
            var authorId = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM b_user WHERE LOGIN='{user.LoginAkaEmail}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin)[0].ID;
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_festival(TITLE,DESCRIPTION,SHORT_DESC,START_AT,END_AT,ORGANIZER_ID,IS_PUBLISHED)" +
                $"VALUES('{Name}','{Description}','{ShortDescription}','{ConvertDateFormatSafe(DateStart)}','{ConvertDateFormatSafe(DateEnd)}',{authorId},1);", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            var result = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM up_festivaliya_festival WHERE TITLE='{Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }
        public void addTags(Tag tag)
        {
            string festivalId = GetFestivalID();
            string tagId = tag.GetTagID();
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_festival_tag (FESTIVAL_ID, TAG_ID)" +
                $"VALUES({festivalId},{tagId})", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
        }
        public string addVenue(Venue venue)
        {
            string festivalId = GetFestivalID();
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_venue(FESTIVAL_ID,TITLE, DESCRIPTION,SHORT_DESC)" +
                $"VALUES({festivalId},'{venue.Name}','{venue.Description}','{venue.ShortDescription}');", PortalInfo.PortalUri, PortalInfo.PortalAdmin);

            var result = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM up_festivaliya_venue WHERE TITLE='{venue.Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }
        public static void addPhotos(string festivalId, string venueId, string eventId, int fileId, Uri portalUri, User adminUser)
        {
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_images(ENTITY_TYPE, ENTITY_ID, FILE_ID,IS_MAIN)" +
                $"VALUES " +
                $"('festival_cover','{festivalId}','{fileId}',1)," +
                $"('venue','{venueId}','{fileId}',1)," +
                $"('event','{eventId}','{fileId}',1)", portalUri, adminUser);
        }
        public void AddPhotoFestival()
        {
            var fileId = PortalDatabaseExecutor.ExecuteQuery($"Select max(file_id) as ID from up_festivaliya_images", PortalInfo.PortalUri, PortalInfo.PortalAdmin)[0].ID;

            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_images(ENTITY_TYPE, ENTITY_ID, FILE_ID,IS_MAIN)" +
                $"VALUES " +
                $"('festival_cover','{GetFestivalID()}','{fileId}',1)", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
        }
        public string GetFestivalID()
        {
            var result = PortalDatabaseExecutor.ExecuteQuery($"select ID from up_festivaliya_festival where title = '{Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }
        public void addTagByName(string Name)
        {
            string festivalId = GetFestivalID();
            var tags = PortalDatabaseExecutor.ExecuteQuery($"select ID from up_festivaliya_tag where title = '{Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            var tagId= tags.Count == 0 ? null : tags[0].ID;
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_festival_tag (FESTIVAL_ID, TAG_ID)" +
                $"VALUES({festivalId},{tagId})", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
        }
        public static string? ConvertDateFormatSafe(string inputDate)
        {
            if (DateTime.TryParseExact(inputDate, "dd.MM.yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date.ToString("yyyy-MM-dd");
            }
            return null;
        }
    }
}
