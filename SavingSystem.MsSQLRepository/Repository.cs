using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingSystem.BaseRepository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected Repository()
        {
            
        }

        public abstract IEnumerable<T> GetAll();
        public abstract T Get(int id);
        public abstract bool Add(T item);
        public abstract bool Update(int id, T item);
        public abstract bool Delete(int id);
    }
}
