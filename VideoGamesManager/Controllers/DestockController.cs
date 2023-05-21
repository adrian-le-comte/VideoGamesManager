using AutoMapper;
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VideoGamesManager.DataAccess.Interfaces;
using VideoGamesManager.Models;

namespace VideoGamesManager.Controllers
{
    //[Authorize(Policy ="NonAdminOnly")]
    public class DestockController : BaseController
    {

        public DestockController(IMapper mapper, IVideoGamesRepository videoGameRepository, ICategoryRepository categoryRepository, IStudioRepository studioRepository, IUsersRepository usersRepository) : base(mapper, videoGameRepository, categoryRepository, studioRepository, usersRepository)
        {
        }

        public IActionResult GenerateBill()
        {
            var allVideoGames = _videoGamesRepository.GetAllVideoGames();

            var selectedGamesJson = TempData["SelectedGames"] as string;
            var selectedGames = new List<Dbo.VideoGame>();
            if (selectedGamesJson != null)
            {
                selectedGames = JsonConvert.DeserializeObject<List<Dbo.VideoGame>>(selectedGamesJson);
            }
            if (selectedGames == null)
            {
                selectedGames = new List<Dbo.VideoGame>();
            }
            TempData["SelectedGames"] = selectedGamesJson;
            DestockViewModel viewModel = new DestockViewModel(allVideoGames, selectedGames);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddGame(string Name, string Price, string Stock, string gameId)
        {
            var id = int.Parse(gameId);
            var game = _videoGamesRepository.GetVideoGameById(id);
            game.Stock = int.Parse(Stock);

            if (TempData.TryGetValue("SelectedGames", out var selectedGamesJson) && selectedGamesJson is string selectedGamesString)
            {
                var selectedGames = JsonConvert.DeserializeObject<List<Dbo.VideoGame>>(selectedGamesString);
                if (selectedGames != null)
                {
                    selectedGames.Add(game);
                }
                else
                {
                    selectedGames = new List<Dbo.VideoGame> { game };
                }
                selectedGamesJson = JsonConvert.SerializeObject(selectedGames);
                TempData["SelectedGames"] = selectedGamesJson;
            }
            else
            {
                selectedGamesJson = JsonConvert.SerializeObject(new List<Dbo.VideoGame> { game });
                TempData["SelectedGames"] = selectedGamesJson;
            }

            return RedirectToAction("GenerateBill");
        }

        public async Task<IActionResult> Print()
        {
            if (TempData.TryGetValue("SelectedGames", out var selectedGamesJson) && selectedGamesJson is string selectedGamesString)
            {
                var selectedGames = JsonConvert.DeserializeObject<List<Dbo.VideoGame>>(selectedGamesString);
                if (selectedGames != null)
                {
                    foreach (var game in selectedGames)
                    {
                        var gameFromId = _videoGamesRepository.GetVideoGameById(game.Id);
                        gameFromId.Stock -= game.Stock;

                        await _videoGamesRepository.UpdateVideoGames(gameFromId);
                    }
                    selectedGames.Clear();
                    TempData["SelectedGames"] =  JsonConvert.SerializeObject(selectedGames);
                    return RedirectToAction("GenerateBill");
                }
            }

            return RedirectToAction("GenerateBill");
        }

        public IActionResult DeleteGame(int gameid)
        {
            var game = _videoGamesRepository.GetVideoGameById(gameid);

            if (TempData.TryGetValue("SelectedGames", out var selectedGamesJson) && selectedGamesJson is string selectedGamesString)
            {
                var selectedGames = JsonConvert.DeserializeObject<List<Dbo.VideoGame>>(selectedGamesString);
                if (selectedGames != null)
                {
                    selectedGames.Remove(game);
                }
                selectedGamesJson = JsonConvert.SerializeObject(selectedGames);
                TempData["SelectedGames"] = selectedGamesJson;
            }
            else
            {
                TempData["SelectedGames"] = selectedGamesJson;
            }

            return RedirectToAction("GenerateBill");
        }
    }
}
