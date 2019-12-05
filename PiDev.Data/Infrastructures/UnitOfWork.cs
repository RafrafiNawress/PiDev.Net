using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Infrastructure
{
    public class UnitOfWork :IUnitOfWork
    {
        IDataBaseFactory DBFactory;
        public UnitOfWork(IDataBaseFactory SolutionFactory)
        {
            DBFactory = SolutionFactory;
        }
        public void commit()
        {
            DBFactory.DataContext.SaveChanges();
        }

        public void Dispose()
        {
            DBFactory.Dispose();
        }

        public IRepositoryBase<T> GetRepositoryBase<T>() where T : class
        {
            return new RepositoryBase<T>(DBFactory);
        }
    }
}
