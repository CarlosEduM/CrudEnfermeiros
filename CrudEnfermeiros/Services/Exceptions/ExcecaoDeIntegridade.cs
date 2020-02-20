using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEnfermeiros.Services.Exceptions
{
    public class ExcecaoDeIntegridade : ApplicationException
    {
        public ExcecaoDeIntegridade(String msg) : base(msg)
        {
        }
    }
}
