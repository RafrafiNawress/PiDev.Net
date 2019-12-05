using Data.Infrastructure;
using PiDev.Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Service
{
    public class EvaluationService : Service<evaluationsheet>, IEvaluationService
    {   // private MyFinanceContext ctx;
        private static IDatabaseFactory dbf = new DatabaseFactory();
        //  private IRepositoryBase<Product> Repo = new RepositoryBase<Product>(dbf);
        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public EvaluationService():base(uow)
        {
            //ctx = dbf.DataContext;
            //uow = unitofwork;


        }
    }
}
