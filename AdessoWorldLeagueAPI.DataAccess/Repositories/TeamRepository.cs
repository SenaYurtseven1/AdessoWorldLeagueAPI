using AdessoWorldLeagueAPI.Domain.Interfaces;
using AdessoWorldLeagueAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.DataAccess.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository() {
            _entites = new List<Team>();
        }
    }
}
