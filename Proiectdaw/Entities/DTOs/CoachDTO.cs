using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities.DTOs
{
    public class CoachDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public Team Team { get; set; }

        public int TeamId { get; set; }
   
    public CoachDTO(Coach coach)
    {
        this.Id = coach.Id;
        this.Name = coach.Name;
        this.Age = coach.Age;
        this.Team = new Team();
        this.TeamId = coach.TeamId;

    }
 }
}

