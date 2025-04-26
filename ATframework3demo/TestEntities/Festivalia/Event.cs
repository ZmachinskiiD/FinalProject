using ATframework3demo.BaseFramework;

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
        public Event(Festival festival, string name = "Событие",  string photoPath = "", string description = "", int dateStart = 0, int dateEnd = 0,int timeStartFromNow = 6,int timeEndFromNow = 7)
        {
            PhotoPath = @"C:\Users\Dima\source\repos\ZmachinskiiD\FinalProject\ATframework3demo\TestData\eventCover.jpg";
            Name = "Событие" + HelperMethods.GetDateTimeSaltString(true, 4);
            Description = "Описание" + HelperMethods.GetDateTimeSaltString(true, 21);
            DateStart = festival.DateStart;
            DateEnd = festival.DateEnd;
            TimeStart = HelperMethods.GetTimeOfFestival(timeStartFromNow);
            TimeEnd = HelperMethods.GetTimeOfFestival(timeEndFromNow);
        }
    }
}
