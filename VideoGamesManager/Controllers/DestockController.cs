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
            var allVideoGames = _mapper.Map<List<VideoGamesViewModel>>(_videoGamesRepository.GetAllVideoGames());

            var selectedGamesJson = TempData["SelectedGames"] as string;
            var selectedGames = new List<VideoGamesViewModel>();
            if (selectedGamesJson != null)
            {
                selectedGames = JsonConvert.DeserializeObject<List<VideoGamesViewModel>>(selectedGamesJson);
            }
            if (selectedGames == null)
            {
                selectedGames = new List<VideoGamesViewModel>();
            }
            TempData["SelectedGames"] = selectedGamesJson;
            for (int i = 0; i < allVideoGames.Count; i++)
            {
                allVideoGames[i].Category = _categoryRepository.GetCategoryById(allVideoGames[i].CategoryId).Name;
                allVideoGames[i].Studio = _studioRepository.GetStudioById(allVideoGames[i].StudioId).Name;
            }
            for (int i = 0; i < selectedGames.Count; i++)
            {
                selectedGames[i].Category = _categoryRepository.GetCategoryById(selectedGames[i].CategoryId).Name;
                selectedGames[i].Studio = _studioRepository.GetStudioById(selectedGames[i].StudioId).Name;
            }
            allVideoGames = allVideoGames.Where(x => x.OwnerId == GetCurrentUserId()).ToList();
            DestockViewModel viewModel = new DestockViewModel(allVideoGames, selectedGames);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddGame(VideoGamesViewModel videoGamesViewModel)
        {
            var game = _mapper.Map<VideoGamesViewModel>(_videoGamesRepository.GetVideoGameByName(videoGamesViewModel.Name));
            game.Stock = videoGamesViewModel.Stock;
            if (TempData.TryGetValue("SelectedGames", out var selectedGamesJson) && selectedGamesJson is string selectedGamesString)
            {
                var selectedGames = JsonConvert.DeserializeObject<List<VideoGamesViewModel>>(selectedGamesString);
                if (selectedGames != null)
                {
                    game.Category = _categoryRepository.GetCategoryById(game.CategoryId).Name;
                    selectedGames.Add(game);
                }
                else
                {
                    game.Category = _categoryRepository.GetCategoryById(game.CategoryId).Name;
                    selectedGames = new List<VideoGamesViewModel> { game };
                }
                selectedGamesJson = JsonConvert.SerializeObject(selectedGames);
                TempData["SelectedGames"] = selectedGamesJson;
            }
            else
            {
                selectedGamesJson = JsonConvert.SerializeObject(new List<VideoGamesViewModel> { game });
                TempData["SelectedGames"] = selectedGamesJson;
            }

            return RedirectToAction("GenerateBill");
        }

        public async Task<IActionResult> Print()
        {
            if (TempData.TryGetValue("SelectedGames", out var selectedGamesJson) && selectedGamesJson is string selectedGamesString)
            {
                var selectedGames = JsonConvert.DeserializeObject<List<VideoGamesViewModel>>(selectedGamesString);
                if (selectedGames != null)
                {
                    for (int i = 0; i < selectedGames.Count; i++)
                    {
                        VideoGamesViewModel? game = selectedGames[i];
                        var gameFromId = _videoGamesRepository.GetVideoGameByNameAndOwner(game.Name, GetCurrentUserId());
                        gameFromId.Stock -= game.Stock;
                        await _videoGamesRepository.UpdateVideoGames(gameFromId);
                        Console.WriteLine(gameFromId);
                    }
                    selectedGames.Clear();
                    TempData["SelectedGames"] = JsonConvert.SerializeObject(selectedGames);
                    return RedirectToAction("GenerateBill");
                }
            }

            return RedirectToAction("GenerateBill");
        }

        public IActionResult DeleteGame(int gameid)
        {
            var game = _mapper.Map<VideoGamesViewModel>(_videoGamesRepository.GetVideoGameById(gameid));

            if (TempData.TryGetValue("SelectedGames", out var selectedGamesJson) && selectedGamesJson is string selectedGamesString)
            {
                var selectedGames = JsonConvert.DeserializeObject<List<VideoGamesViewModel>>(selectedGamesString);
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
