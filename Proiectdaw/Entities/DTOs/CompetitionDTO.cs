using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities.DTOs
{
    public class CompetitionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Prizepool { get; set; }

        public List<TeamCompetition> TeamCompetitions { get; set; }

        public CompetitionDTO(Competition competition)
        {
            this.Id = competition.Id;
            this.Name = competition.Name;
            this.Prizepool = competition.Prizepool;
            this.TeamCompetitions = new List<TeamCompetition>();
        }
    }
}
