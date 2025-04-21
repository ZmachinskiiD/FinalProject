namespace ATframework3demo.TestEntities.Festivalia
{
    public class Venue
    {
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public Venue(string name, string shortDescription, string photoPath, string description)
        {
            PhotoPath = photoPath;
            Name = name;
            ShortDescription = shortDescription;
            Description = description;

        }
    }
}
