using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using System.Globalization;

namespace ATframework3demo.TestEntities.Festivalia
{
    public class Venue
    {
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public PortalInfo PortalInfo { get; set; }
        public Venue(string name = "��������", string shortDescription = "������� ��������", string photoPath = "���� � ����", string description = "�������� ��������", PortalInfo? portalInfo = null)
        {
            PhotoPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..")) + @"\TestData\venueCover.jpg";
            Name = "��������" + HelperMethods.GetDateTimeSaltString(true, 10);
            ShortDescription = "������� " + HelperMethods.GetDateTimeSaltString(true, 4);
            Description = "������ �������� " + HelperMethods.GetDateTimeSaltString(true, 21);
            PortalInfo = portalInfo;

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
                $"VALUES({venueID},'{Event.Name}','{Event.Description}','{HelperMethods.ConvertDateFormat(Event.DateStart) + ' ' + Event.TimeStart}', '{HelperMethods.ConvertDateFormat(Event.DateEnd) + ' ' + Event.TimeEnd}');", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            var result = PortalDatabaseExecutor.ExecuteQuery($"Select ID FROM up_festivaliya_event WHERE TITLE='{Event.Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }
       
        public void AddPhotoVenue()
        {
            var fileId = PortalDatabaseExecutor.ExecuteQuery($"Select max(file_id) as ID from up_festivaliya_images", PortalInfo.PortalUri, PortalInfo.PortalAdmin)[0].ID;

            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_images(ENTITY_TYPE, ENTITY_ID, FILE_ID,IS_MAIN)" +
                $"VALUES " +
                $"('venue','{GetVenueID()}','{fileId}',1)", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
        }
    }
}
