using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.Domain.Models
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public List<Team> Teams { get; set; }
    }
}
