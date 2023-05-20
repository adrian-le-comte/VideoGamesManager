using VideoGamesManager.Dbo;

namespace VideoGamesManager.Models
{
    public class DestockViewModel
    {
        public List<VideoGame> Games { get; set; }
        public List<VideoGame> SelectedGames { get; set; }
        public int AddedGameId { get; set; }

        public DestockViewModel(List<VideoGame> games, List<VideoGame> selectedGames) {
            Games = games;
            SelectedGames = selectedGames;
        }
    }
}
