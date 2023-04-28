using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATALAYER.Repository
{
    public interface IPasswordLockerRepo<T> where T : class
    {
        public T Get(int id);
        public IEnumerable<T> GetAll();
        public int Add(T model);
        public int Edit(T model);
        public int Delete(int id);
    }
}
