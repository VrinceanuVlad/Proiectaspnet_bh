using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiectdaw.Entities;
using Proiectdaw.Entities.DTOs;
using Proiectdaw.Repositories.CompetitionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {

        private readonly ICompetitionRepository _repository;
        public CompetitionController(ICompetitionRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCompetitionByName(string name)
        {
            var competition = await _repository.GetByName(name);
            return Ok(new CompetitionDTO(competition));

        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateCompetitionDTO dto)
        {
            Competition newCompetition = new Competition();
            newCompetition.Name = dto.Name;
            newCompetition.Prizepool = dto.Prizepool;

            _repository.Create(newCompetition);

            await _repository.SaveAsync();

            return Ok(new CompetitionDTO(newCompetition));




        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(int id)
        {
            var competition = await _repository.GetByIdAsync(id);

            if (competition == null)
            {
                return NotFound("Competition does not exist");
            }

            _repository.Delete(competition);
            await _repository.SaveAsync();

            return NoContent();

        }

    }
}
