namespace VideoGamesManager.Dbo
{
    public class VideoGame : IObjectWithId
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }
        public int Min_age { get; set; }

        public int Stock { get; set; }
        public string Description { get; set; }

        public int Owner { get; set; }
    }
}
