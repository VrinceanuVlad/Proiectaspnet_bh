using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities.DTOs
{
    public class CreateTeamDTO
    {
        public string Name{ get; set; }
        public Coach Coach { get; set; }

    }
}
