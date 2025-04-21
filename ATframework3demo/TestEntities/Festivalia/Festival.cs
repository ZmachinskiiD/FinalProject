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
        public Festival(string name, string shortDescription, string photoPath, string description,string dateStart,string dateEnd,string? mapPath=null)
        {
            PhotoPath = photoPath;
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
            MapPath = mapPath;

        }
    }
}
