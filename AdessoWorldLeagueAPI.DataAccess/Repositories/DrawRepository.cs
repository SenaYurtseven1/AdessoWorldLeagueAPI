using AdessoWorldLeagueAPI.DataAccess.Context;
using AdessoWorldLeagueAPI.Domain.Interfaces;
using AdessoWorldLeagueAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.DataAccess.Repositories
{
    public class DrawRepository : BaseRepository<Draw>, IDrawRepository
    {
        public DrawRepository(AppDbContext context) : base(context)
        {
        }
    }
}
