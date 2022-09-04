using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities.DTOs
{
    public class CreatePlayerDTO
    {
        public string Name { get; set; }
        public Team Team { get; set; }
    }
}
