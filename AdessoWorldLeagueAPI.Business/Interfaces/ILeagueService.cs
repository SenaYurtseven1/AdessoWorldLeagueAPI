using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.Business.Interfaces
{
    public interface ILeagueService
    {
        Task<object> GenerateGroupAsync(int numberOfGroups, string DrawName, string DrawSurname);
    }
}
