using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities
{
    public class Competition
    {
        public int Id{ get; set; }
        public string Name { get; set; }

        public int Prizepool { get; set; }

        public ICollection<TeamCompetition> TeamCompetitions { get; set; }
    }
}
