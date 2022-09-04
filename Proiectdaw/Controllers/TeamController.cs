using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiectdaw.Entities;
using Proiectdaw.Entities.DTOs;
using Proiectdaw.Repositories.TeamRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _repository;
        public TeamController(ITeamRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _repository.GetAllTeamsWithCoches();
            var teamsToReturn = new List<TeamDTO>();

            foreach (var team in teams)
            {
                teamsToReturn.Add(new TeamDTO(team));
            }
            return Ok(teamsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _repository.GetByIdWithCouches(id);
            return Ok(new TeamDTO(team));

        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDTO dto)
        {
            Team newTeam = new Team();
            newTeam.Name = dto.Name;
            newTeam.Coach = dto.Coach;

            _repository.Create(newTeam);

            await _repository.SaveAsync();

            return Ok(new TeamDTO(newTeam));
            



        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam (int id)
        {
            var team = await _repository.GetByIdAsync(id);

            if(team ==null)
            {
                return NotFound("Team does not exist");
            }

            _repository.Delete(team);
            await _repository.SaveAsync();

            return NoContent();

        }


    }
}
