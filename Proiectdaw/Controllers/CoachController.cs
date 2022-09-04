using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiectdaw.Entities.DTOs;
using Proiectdaw.Repositories.TeamRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiectdaw.Entities;
using Proiectdaw.Repositories.CoachRepository;

namespace Proiectdaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {

        private readonly ICoachRepository _repository;
        public CoachController(ICoachRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoaches()
        {
            var coaches = await _repository.GetAllCoachesWithTeams();
            var coachesToReturn = new List<CoachDTO>();

            foreach (var coach in coaches)
            {
                coachesToReturn.Add(new CoachDTO(coach));
            }
            return Ok(coachesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoachById(int id)
        {
            var coach = await _repository.GetByIdWithTeams(id);
            return Ok(new CoachDTO(coach));

        }

        [HttpPost]
        public async Task<IActionResult> CreateCoach(CreateCoachDTO dto)
        {
            Coach newCoach = new Coach();
            newCoach.Name = dto.Name;
            newCoach.Team = dto.Team;

            _repository.Create(newCoach);

            await _repository.SaveAsync();

            return Ok(new CoachDTO(newCoach));




        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            var coach = await _repository.GetByIdAsync(id);

            if (coach == null)
            {
                return NotFound("Coach does not exist");
            }

            _repository.Delete(coach);
            await _repository.SaveAsync();

            return NoContent();

        }

    }
}
