using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDeDados.Contexto;
using BancoDeDados.Generico;

namespace Servico
{
    public class BaseServico<T> : IDisposable where T : class
    {
        protected P3ImageContext contexto;
        protected GenericRepository<T> repositorio;

        public virtual List<T> GetAll()
        {
            return repositorio.Get().ToList();
        }
        public virtual T Get(params object[] keys)
        {
            return repositorio.Get(keys);
        }

        public virtual void Insert(T entity)
        {
            repositorio.Insert(entity);
            contexto.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            repositorio.Update(entity);
            contexto.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            repositorio.Delete(entity);
            contexto.SaveChanges();
        }

        public virtual void Delete(params object[] keys)
        {
            var entity = repositorio.Get(keys);
            repositorio.Delete(entity);
            contexto.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    contexto.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
