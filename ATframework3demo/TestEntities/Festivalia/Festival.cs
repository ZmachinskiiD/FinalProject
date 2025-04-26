using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;

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
        public string Tag { get; set; }
        public PortalInfo PortalInfo { get; }
        public Festival(Tag tag,int dateStartFromToday = 0, int dateEndFromToday = 0, string? mapPath=null)
        {
            PhotoPath = @"C:\Users\Dima\source\repos\ZmachinskiiD\FinalProject\ATframework3demo\TestData\eventCover.jpg";
            Name = "Название" + HelperMethods.GetDateTimeSaltString(true, 4);
            ShortDescription = "Краткое" + HelperMethods.GetDateTimeSaltString(true, 4);
            Description = "Полное Описание " + HelperMethods.GetDateTimeSaltString(true, 21);
            DateStart = HelperMethods.GetDate(dateStartFromToday);
            DateEnd = HelperMethods.GetDate(dateEndFromToday);
            MapPath = @"C:\Users\Dima\source\repos\ZmachinskiiD\FinalProject\ATframework3demo\TestData\Карта.jpeg";
            Tag = tag.Name;

        }

        public string insertFestival(User user)
        {
            var authorId = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM b_user WHERE LOGIN='{user.LoginAkaEmail}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin)[0].ID;
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_festival(TITLE,DESCRIPTION,SHORT_DESC,START_AT,END_AT,ORGANIZER_ID,IS_PUBLISHED)" +
                $"VALUES('{Name}','{Description}','{ShortDescription}','{DateStart}','{DateEnd}',{authorId},1);", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
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
        public string GetFestivalID()
        {
            var result = PortalDatabaseExecutor.ExecuteQuery($"select ID from up_festivaliya_festival where title = '{Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }
    }
}
