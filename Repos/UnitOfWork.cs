using System;
using System.Threading.Tasks;
using FixtureApp.Data;
using FixtureApp.Repos.Interface;

namespace FixtureApp.Repos
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationDbContext _DbContext;

        public MatchRepository MatchRepository { get; private set; }
        public TeamRepository TeamRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this._DbContext = context;
            this.MatchRepository = new MatchRepository(this._DbContext);
            this.TeamRepository = new TeamRepository(this._DbContext);
        }

        public  void Commit()
        {
             this._DbContext.SaveChanges();
        }

        public void Dispose()
        {
            this._DbContext.Dispose();
        }
    }
}
