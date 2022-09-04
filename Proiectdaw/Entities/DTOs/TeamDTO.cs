using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coach Coach { get; set; }

        public List<Player> Players { get; set; }

        public List<TeamCompetition> TeamCompetitions { get; set; }

        public TeamDTO(Team team)
        {
            this.Id = team.Id;
            this.Name = team.Name;
            this.Coach = new Coach();
            this.Players = new List<Player>();
            this.TeamCompetitions = new List<TeamCompetition>();

        }
    }
}
