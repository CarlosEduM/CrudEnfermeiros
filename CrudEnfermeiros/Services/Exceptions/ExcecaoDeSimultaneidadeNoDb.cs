using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEnfermeiros.Services.Exceptions
{
    public class ExcecaoDeSimultaneidadeNoDb : ApplicationException
    {
        public ExcecaoDeSimultaneidadeNoDb(string msg) : base(msg)
        {
        }
    }
}
