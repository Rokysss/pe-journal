using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEJournal.DataAccess
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        public abstract IEnumerable<T> GetAll();
        public abstract void Create(T item);
        public abstract void Update(T item);
        public abstract void Delete(int id);
    }
}
