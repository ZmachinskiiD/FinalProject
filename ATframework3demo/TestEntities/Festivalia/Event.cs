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
        public Event(string name,  string photoPath, string description, string dateStart, string dateEnd,string timeStart,string timeEnd)
        {
            PhotoPath = photoPath;
            Name = name;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
           TimeStart = timeStart;
            TimeEnd = timeEnd;
        }
    }
}
