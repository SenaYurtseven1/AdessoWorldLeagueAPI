using AdessoWorldLeagueAPI.Business.Interfaces;
using AdessoWorldLeagueAPI.Domain.Interfaces;
using AdessoWorldLeagueAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly IDrawRepository _drawRepository;

        public LeagueService(ITeamRepository teamRepository, IGroupRepository groupRepository, IDrawRepository drawRepository)
        {
            _teamRepository = teamRepository;
            _groupRepository = groupRepository;
            _drawRepository = drawRepository;
        }

        public async Task<object> GenerateGroupAsync(int numberOfGroups, string drawName, string drawSurname)
        {
            // Retrieve all teams from the database
            var teams = (await _teamRepository.GetAllAsync()).ToList();

            // Retrieve all groups from the database
            var groups = (await _groupRepository.GetAllAsync()).ToList();

            // Delete previous draw records
            await _drawRepository.DeleteAllAsync();

            // Shuffle teams randomly
            var random = new Random();
            teams = teams.OrderBy(t => random.Next()).ToList();

            // Determine the required number of countries per group
            int requiredCountryCount = numberOfGroups == 4 ? 8 : 4;
            int groupIndex = 0; // Index to navigate through the groups

            // Dictionary to keep track of the number of countries in each group
            var groupCountryCounts = new Dictionary<int, HashSet<string>>();
            foreach (var group in groups)
            {
                groupCountryCounts[group.Id] = new HashSet<string>();
            }

            // Loop through shuffled teams and assign them to groups
            foreach (var team in teams)
            {
                bool teamAdded = false;

                // Try to add the team to an appropriate group
                for (int i = 0; i < numberOfGroups; i++)
                {
                    var group = groups[groupIndex];

                    // Check if the group doesn't already have a team from the same country
                    // and if it meets the required number of countries
                    if (!groupCountryCounts[group.Id].Contains(team.CountryId.ToString()) &&
                        groupCountryCounts[group.Id].Count < requiredCountryCount)
                    {
                        team.GroupId = group.Id; // Assign group ID to the team
                        group.Teams.Add(team); // Add the team to the group

                        // Update the country count for the group
                        groupCountryCounts[group.Id].Add(team.CountryId.ToString());

                        // Create a draw record
                        var draw = new Draw
                        {
                            DrawnName = drawName,
                            DrawnSurname = drawSurname,
                            DrawDate = DateTime.Now,
                            GroupId = group.Id,
                            TeamId = team.Id
                        };

                        // Save the draw record to the database
                        await _drawRepository.AddAsync(draw);

                        teamAdded = true; // Team successfully added
                        break;
                    }

                    // Move to the next group
                    groupIndex++;

                    // If the group index exceeds the number of groups, reset to the first group
                    if (groupIndex >= numberOfGroups)
                    {
                        groupIndex = 0;
                    }
                }

                // If a suitable group couldn't be found, return an error
                if (!teamAdded)
                {
                    return new { error = $"Unable to add team {team.Name} ({team.Country}) to any group. Please check group constraints." };
                }
            }

            // Return the groups and teams in the desired JSON format
            var result = new
            {
                groups = groups.Select(g => new
                {
                    groupName = g.GroupName,
                    teams = g.Teams.Select(t => new
                    {
                        name = t.Name
                    }).ToList()
                }).ToList()
            };

            return result;
        }
    }
}
