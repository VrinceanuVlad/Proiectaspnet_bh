using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiectdaw.Entities;
using Proiectdaw.Entities.DTOs;
using Proiectdaw.Repositories.PlayerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _repository;
        public PlayerController(IPlayerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _repository.GetAllPlayersWithTeams();
            var playersToReturn = new List<PlayerDTO>();

            foreach (var player in players)
            {
                playersToReturn.Add(new PlayerDTO(player));
            }
            return Ok(playersToReturn);
        }

        [HttpGet("{age}")]
        public async Task<IActionResult> GetPlayerByAge(int age)
        {
            var player = await _repository.GetByAge(age);
            return Ok(new PlayerDTO(player));

        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerDTO dto)
        {
            Player newPlayer = new Player();
            newPlayer.Name = dto.Name;
            newPlayer.Team = dto.Team;

            _repository.Create(newPlayer);

            await _repository.SaveAsync();

            return Ok(new PlayerDTO(newPlayer));




        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var player = await _repository.GetByIdAsync(id);

            if (player == null)
            {
                return NotFound("Player does not exist");
            }

            _repository.Delete(player);
            await _repository.SaveAsync();

            return NoContent();

        }

    }
}
