using AdessoWorldLeagueAPI.Business.Interfaces;
using AdessoWorldLeagueAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.Business.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IGroupRepository _groupRepository;

        public LeagueService(ITeamRepository teamRepository, IGroupRepository groupRepository)
        {
            _teamRepository = teamRepository;
            _groupRepository = groupRepository;
        }

        public async Task<List<Group>> GenerateGroupAsync(int numberOfGroups, int teamsPerGroup)
        {
            throw new NotImplementedException();
        }
    }
}
