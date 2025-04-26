using atFrameWork2.TestEntities;
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
        public Festival(string name, string shortDescription, string photoPath, string description,string dateStart,string dateEnd, string tag, string? mapPath=null)
        {
            PhotoPath = photoPath;
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
            MapPath = mapPath;
            Tag = tag;

        }

        public static string InsertTag(string name, Uri portalUri, User adminUser)
        {
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_tag (TITLE) VALUES('{name}')", portalUri, adminUser);
            var result = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM up_festivaliya_tag WHERE TITLE='{name}'", portalUri, adminUser);
            return result.Count == 0 ? null : result[0].ID;
        }
        public static string insertFestival(Festival festival, Uri portalUri, User adminUser, string AuthorLogin)
        {
            var author= PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM b_user WHERE LOGIN='{AuthorLogin}'", portalUri, adminUser);
            var authorId= author.Count == 0 ? null : author[0].ID;
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_festival(TITLE,DESCRIPTION,SHORT_DESC,START_AT,END_AT,ORGANIZER_ID,IS_PUBLISHED)" +
                $"VALUES('{festival.Name}','{festival.Description}','{festival.ShortDescription}','{festival.DateStart}','{festival.DateEnd}',{authorId},1);", portalUri, adminUser);
            var result = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM up_festivaliya_festival WHERE TITLE='{festival.Name}'", portalUri, adminUser);
            return result.Count == 0 ? null : result[0].ID;
        }
        public static void addTags(string festivalId, string tagId, Uri portalUri, User adminUser)
        {
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_festival_tag (FESTIVAL_ID, TAG_ID)" +
                $"VALUES({festivalId},{tagId})", portalUri, adminUser);
        }
        public static string addVenue(string festivalId, Venue venue, Uri portalUri, User adminUser)
        {
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_venue(FESTIVAL_ID,TITLE, DESCRIPTION,SHORT_DESC)" +
                $"VALUES({festivalId},'{venue.Name}','{venue.Description}','{venue.ShortDescription}');", portalUri, adminUser);
            var result = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM up_festivaliya_venue WHERE TITLE='{venue.Name}'", portalUri, adminUser);
            return result.Count == 0 ? null : result[0].ID;

        }
        public static string addEvent(string venueId, Event Event, Uri portalUri, User adminUser)
        {
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_event(VENUE_ID, TITLE, DESCRIPTION,START_AT,END_AT)" +
                $"VALUES({venueId},'{Event.Name}','{Event.Description}','{Event.DateStart + ' ' + Event.TimeStart}', '{Event.DateEnd + ' ' + Event.TimeEnd}');", portalUri, adminUser);
            var result = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM up_festivaliya_event WHERE TITLE='{Event.Name}'", portalUri, adminUser);
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
    }
}
