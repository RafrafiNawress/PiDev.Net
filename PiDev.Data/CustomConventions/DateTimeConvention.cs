using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.CustomConventions
{
    public class DateTimeConvention:Convention
    {
        public DateTimeConvention()
        {
            Properties<DateTime>().
                Configure(p => p.HasColumnType("datetime2"));
        }
    }
}
