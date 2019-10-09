using System;
using System.Collections.Generic;
using System.Linq;
using FixtureApp.Data;
using FixtureApp.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace FixtureApp.Repos
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this._dbSet.ToList();
        }

        public T GetById(int id)
        {
            return this._dbSet.Find(id);
        }

        public void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            this._dbSet.Attach(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            this._dbSet.Remove(entity);
        }
    }
}
