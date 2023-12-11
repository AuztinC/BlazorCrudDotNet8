﻿using BlazorCrudDotNet8.Shared.Entities;
using BlazorCrudDotNet8.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<Game>> GetGameById(int id)
        {
            var game = await _gameService.GetGameById(id);
            return Ok(game);

        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGames(Game game)
        {
            var addedGame = await _gameService.AddGame(game);
            return Ok(addedGame);

        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Game>> EditGames(int id, Game game)
        {
            var updatedGame = await _gameService.EditGame(id, game);
            return Ok(updatedGame);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGames(int id)
        {
            var result = await _gameService.DeleteGame(id);
            return Ok(result);

        }
    }
}
