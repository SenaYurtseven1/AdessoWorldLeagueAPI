using AdessoWorldLeagueAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.DataAccess.Repositories
{
    public class GroupRepository : BaseRepository<Group>,IGroupRepository
    {
        public GroupRepository() { 
            _entites = new List<Group>();
        }
    }
}
