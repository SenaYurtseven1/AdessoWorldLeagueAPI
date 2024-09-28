using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.Domain.Models
{
    public class Draw : BaseEntity
    {
        public string DrawnName { get; set; } 
        public string DrawnSurname { get; set; } 
        public DateTime DrawDate { get; set; } 

        public int GroupId { get; set; } 
        public AdessoGroup Group { get; set; }

        public int TeamId { get; set; } 
        public Team Team { get; set; }
    }
}
