using AdessoWorldLeagueAPI.Domain.Models;

namespace AdessoWorldLeagueAPI.Presentation.DTO
{
    public class DrawDTO
    {
        public string DrawerName { get; set; }
        public string DrawerSurname { get; set; }
        public int GroupCount { get; set; } // 4 or 8
    }
}
