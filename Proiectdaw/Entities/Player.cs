using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }



    }
}
