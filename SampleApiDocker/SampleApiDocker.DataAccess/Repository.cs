using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SampleApiDocker.DataAccess
{
    public class Repository<T> where T : class
    {
        private readonly EFContext context;
        private readonly DbSet<T> dbSet;

        public Repository()
        {
            context = new EFContext();
            dbSet = context.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> query)
        {
            return dbSet.SingleOrDefaultAsync(query).Result;
        }

        public IList<T> FindAll()
        {
            return dbSet.AsQueryable().ToListAsync().Result;
        }

        public IList<T> FindAll(Expression<Func<T, bool>> query)
        {
            return dbSet.AsQueryable().Where(query).ToListAsync().Result;
        }

        public bool Exists(Expression<Func<T, bool>> query)
        {
            return dbSet.AnyAsync(query).Result;
        }

        public long Count()
        {
            return dbSet.LongCountAsync().Result;
        }

        public long Count(Expression<Func<T, bool>> query)
        {
            return dbSet.LongCountAsync(query).Result;
        }

        public virtual T Insert(T document)
        {
            dbSet.Add(document);
            context.SaveChanges();

            return document;
        }

        public T Update(T document)
        {
            dbSet.Update(document);
            context.SaveChanges();

            return document;
        }

        public void Delete(T document)
        {
            dbSet.Remove(document);
            context.SaveChanges();
        }
    }
}
