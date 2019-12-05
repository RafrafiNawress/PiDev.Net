using PiDev.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T:class
    {
        private Context ctx = null;
        readonly IDbSet<T> DbSet;

        public RepositoryBase(IDataBaseFactory Factory)
        {
            ctx = Factory.DataContext;
            DbSet=ctx.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        
        public void Delete(Expression<Func<T, bool>> Condition)
        {
            foreach (T entity in DbSet.Where(Condition))
            {
                DbSet.Remove(entity);
            }
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
        public T Get(Expression<Func<T, bool>> Condition)
        {
            return DbSet.Where(Condition).FirstOrDefault();
        }

        public T GetById(string id)
        {
            return DbSet.Find(id);
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> Condition = null, Expression<Func<T, bool>> OrderBy = null)
        {
            // return DbSet.Where(Condition).OrderBy(OrderBy1);
            IQueryable<T> Query = DbSet;
            if (Condition != null)
                Query = Query.Where(Condition);
            if (OrderBy != null)
                Query = Query.OrderBy(OrderBy);
            return Query.AsEnumerable();
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            ctx.Entry(entity).State = EntityState.Modified;
                

        }
    }
}
