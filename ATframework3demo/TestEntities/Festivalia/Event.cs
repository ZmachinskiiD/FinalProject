using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;

namespace ATframework3demo.TestEntities.Festivalia
{
    public class Event
    {
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public PortalInfo PortalInfo { get; set; }
        public Event(int dateStart = 0, int dateEnd = 0, int timeStartFromNow = 6, int timeEndFromNow = 7, string name = "Событие",  string photoPath = "", string description = "", PortalInfo? portalInfo = null)
        {
            PhotoPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..")) + @"\TestData\eventCover.jpg";
            Name = "Событие" + HelperMethods.GetDateTimeSaltString(true, 4);
            Description = "Описание" + HelperMethods.GetDateTimeSaltString(true, 21);
            DateStart = HelperMethods.GetDate(dateStart);
            DateEnd = HelperMethods.GetDate(dateEnd);
            TimeStart = HelperMethods.GetTimeOfFestival(timeStartFromNow);
            TimeEnd = HelperMethods.GetTimeOfFestival(timeEndFromNow);
            PortalInfo = portalInfo;
        }
        public void AddPhotoEvent()
        {
            var fileId = PortalDatabaseExecutor.ExecuteQuery($"Select max(file_id) as ID from up_festivaliya_images", PortalInfo.PortalUri, PortalInfo.PortalAdmin)[0].ID;

            PortalDatabaseExecutor.ExecuteQuery($"INSERT INTO up_festivaliya_images(ENTITY_TYPE, ENTITY_ID, FILE_ID,IS_MAIN)" +
                $"VALUES " +
                $"('event','{GetEventID()}','{fileId}',1)", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
        }

        public string GetEventID()
        {
            var result = PortalDatabaseExecutor.ExecuteQuery($"select ID from up_festivaliya_event where title = '{Name}'", PortalInfo.PortalUri, PortalInfo.PortalAdmin);
            return result[0].ID;
        }

    }
}
