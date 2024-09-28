using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.Domain.Models
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int? GroupId { get; set; }

        public Country Country { get; set; }
        public AdessoGroup AdessoGroup { get; set; }
        public ICollection<Draw> Draws { get; set; } = new List<Draw>();
    }
}
