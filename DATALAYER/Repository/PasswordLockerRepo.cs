using DATALAYER.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATALAYER.Repository
{
    public class PasswordLockerRepo<T> : IPasswordLockerRepo<T> where T : class
    {
        private PasswordLockerContext context;

        public PasswordLockerRepo(PasswordLockerContext context)
        {
            this.context = context;
        }

        public int Add(T model)
        {
            context.Set<T>().Add(model);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            T model = context.Set<T>().Find(id);
            context.Set<T>().Remove(model);
            return context.SaveChanges();
        }

        public int Edit(T model)
        {
            context.Entry(model).State = /*System.Data.Entity.*/EntityState.Modified;
            return context.SaveChanges();
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
    }
}
