using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FixtureApp.Data;
using FixtureApp.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace FixtureApp.Repos
{
    public class MatchRepository : GenericRepository<Data.Match>, IMatchRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MatchRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override IEnumerable<Data.Match> GetAll()
        {
            return _dbContext.Matches.Include(l => l.TeamLeft).Include(r => r.TeamRight).ToList();
        }
    }
}
