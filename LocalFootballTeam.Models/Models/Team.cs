using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFootballTeam.Models.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Addres { get; set; } = string.Empty;
        public string StartYear { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;

    }
}
