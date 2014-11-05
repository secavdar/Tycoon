using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Project.Domain.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;

        internal BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return _set.AsQueryable();
        }
        public virtual List<T> List()
        {
            return _set.ToList();
        }
        public virtual List<T> List(Expression<Func<T, bool>> predicate)
        {
            return _set.Where(predicate).ToList();
        }
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _set.Where(predicate);
        }
        public virtual T Find(object id)
        {
            return _set.Find(id);
        }
        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return _set.FirstOrDefault(predicate);
        }
        public virtual T Add(T entity)
        {
            _set.Add(entity);
            return entity;
        }
        public virtual void Update(T entity)
        {
            _set.Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
        public virtual void Delete(object id)
        {
            T entity = Find(id);
            _set.Remove(entity);
        }
        public virtual void DeleteMany(Expression<Func<T, bool>> predicate)
        {
            var list = _set.Where(predicate).ToList();

            if (list.Count != 0)
                _set.RemoveRange(list);
        }
    }
}