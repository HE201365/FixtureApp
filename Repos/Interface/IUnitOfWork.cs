using System;
using System.Threading.Tasks;

namespace FixtureApp.Repos.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
