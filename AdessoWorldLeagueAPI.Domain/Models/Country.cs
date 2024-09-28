using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.Domain.Models
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
