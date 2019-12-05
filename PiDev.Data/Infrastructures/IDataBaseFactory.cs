using PiDev.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Infrastructure
{
    public interface IDataBaseFactory:IDisposable
    {
         Context DataContext { get;}
        //void Dispose(); hidden
    }
}
