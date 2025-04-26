using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;

namespace ATframework3demo.TestEntities.Festivalia
{
    public class Venue
    {
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public PortalInfo PortalInfo { get; set; }
        public Venue(string name = "Площадка", string shortDescription = "Краткое описание", string photoPath = "Путь к фото", string description = "Описание площадки")
        {
            PhotoPath = @"C:\Users\Dima\source\repos\ZmachinskiiD\FinalProject\ATframework3demo\TestData\venueCover.jpg";
            Name = "Площадка" + HelperMethods.GetDateTimeSaltString(true, 4);
            ShortDescription = "Краткое " + HelperMethods.GetDateTimeSaltString(true, 4);
            Description = "Полное Описание " + HelperMethods.GetDateTimeSaltString(true, 21);

        }
        public string GetVenueID()
        {
            var result = PortalDatabaseExecutor.ExecuteQuery($"select ID from up_festivaliya_venue where title = '{Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }
        public string AddEvent(Event Event)
        {
            var venueID = GetVenueID();
            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_event(VENUE_ID, TITLE, DESCRIPTION,START_AT,END_AT)" +
                $"VALUES({venueID},'{Event.Name}','{Event.Description}','{Event.DateStart + ' ' + Event.TimeStart}', '{Event.DateEnd + ' ' + Event.TimeEnd}');", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            var result = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM up_festivaliya_event WHERE TITLE='{Event.Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }
    }
}
