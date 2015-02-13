using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BancoDeDados.Generico
{
    public class GenericRepository<T> where T : class
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        private DbSet<T> EntitySet
        {
            get { return _context.Set<T>(); }
        }

        public IEnumerable<T> Get()
        {
            return EntitySet.AsQueryable();
        }

        public T Get(params object[] keys)
        {
            return EntitySet.Find(keys);
        }

        public T Get(Expression<Func<T, bool>> criteria)
        {
            return EntitySet.FirstOrDefault(criteria);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> criteria)
        {
            return EntitySet.Where(criteria);
        }

        public T Insert(T entity)
        {
            return EntitySet.Add(entity);
        }


        public void Update(T entity)
        {
            EntitySet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            EntitySet.Attach(entity);
            _context.Entry(entity).State = EntityState.Unchanged;

            foreach (var prop in updatedProperties)
            {
                _context.Entry(entity).Property(prop).IsModified = true;
            }

            //desabilito a validacao automatica do ef porque esse update e para colunas especificas
            _context.Configuration.ValidateOnSaveEnabled = false;

        }


        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                EntitySet.Attach(entity);
            }

            EntitySet.Remove(entity);
        }

    }
}
