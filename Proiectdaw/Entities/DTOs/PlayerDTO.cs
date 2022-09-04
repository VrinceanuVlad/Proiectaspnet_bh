using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities.DTOs
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public PlayerDTO(Player player)
        {
            this.Id = player.Id;
            this.Name = player.Name;
            this.Team = new Team();
            this.Age = player.Age;
            this.TeamId = player.TeamId;
        }
    }
}
