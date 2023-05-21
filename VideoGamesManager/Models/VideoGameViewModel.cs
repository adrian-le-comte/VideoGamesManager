namespace VideoGamesManager.Models
{
    public class VideoGameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Min_age { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int OwnerId { get; set; }
        public string Category { get; set; }
        public int StudioId { get; set; }

        public string Studio { get; set; }
    }
}
