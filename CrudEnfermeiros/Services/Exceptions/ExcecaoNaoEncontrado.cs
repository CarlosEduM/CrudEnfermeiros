using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEnfermeiros.Services.Exceptions
{
    public class ExcecaoNaoEncontrado : ApplicationException
    {
        public ExcecaoNaoEncontrado(String msg) : base(msg)
        {
        }
    }
}
