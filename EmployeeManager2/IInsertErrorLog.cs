using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager2
{
    public interface IInsertErrorLog
    {
        void saveerror(Exception ex);
    }
}
