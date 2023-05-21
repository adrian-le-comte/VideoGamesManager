using VideoGamesManager.Dbo;

namespace VideoGamesManager.Models
{
    public class DestockViewModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; } 
        public List<VideoGamesViewModel> Games { get; set; }
        public List<VideoGamesViewModel> SelectedGames { get; set; }
        public int AddedGameId { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
        public string Studio { get; set; }

        public int Min_age { get; set; }
        public DestockViewModel(List<VideoGamesViewModel> games, List<VideoGamesViewModel> selectedGames) {
            Games = games;
            SelectedGames = selectedGames;
        }
    }
}
