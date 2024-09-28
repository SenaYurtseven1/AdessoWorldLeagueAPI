using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.Domain.Models
{
    public class AdessoGroup : BaseEntity
    {
        public string GroupName { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
        public ICollection<Draw> Draws { get; set; } = new List<Draw>();
    }
}
