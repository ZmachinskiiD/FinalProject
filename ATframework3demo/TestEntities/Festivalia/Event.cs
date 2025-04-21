namespace ATframework3demo.TestEntities.Festivalia
{
    public class Event
    {
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateTimeStart { get; set; }
        public string DateTimeEnd { get; set; }
        public Event(string name,  string photoPath, string description, string dateTimeStart, string dateTimeEnd)
        {
            PhotoPath = photoPath;
            Name = name;
            Description = description;
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
        }
    }
}
