using PiDev.Data;
using Solution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Infrastructure
{
    public class DataBaseFactory : Disposable,IDataBaseFactory
    {
        private Context dataContext;

        public Context DataContext 
        {
            get { return dataContext; }
            
        }

        public DataBaseFactory()
        {
            dataContext = new Context();
        }
        protected override void DisposeCore() //libérer l'espace mémoire occupé par le ctx
        {
            if(DataContext!=null)

           DataContext.Dispose();
            
        }


    }
}
