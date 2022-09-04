using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coach Coach { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<TeamCompetition> TeamCompetitions { get; set; }


    }
}
