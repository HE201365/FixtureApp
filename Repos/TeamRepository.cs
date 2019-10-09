using System;
using FixtureApp.Data;
using FixtureApp.Repos.Interface;

namespace FixtureApp.Repos
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TeamRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
