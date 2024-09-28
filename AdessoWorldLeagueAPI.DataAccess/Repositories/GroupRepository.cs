﻿using AdessoWorldLeagueAPI.DataAccess.Context;
using AdessoWorldLeagueAPI.Domain.Interfaces;
using AdessoWorldLeagueAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdessoWorldLeagueAPI.DataAccess.Repositories
{
    public class GroupRepository : BaseRepository<AdessoGroup>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
