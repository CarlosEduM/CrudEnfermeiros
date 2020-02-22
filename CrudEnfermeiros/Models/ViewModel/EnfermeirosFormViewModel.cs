using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEnfermeiros.Models.ViewModel
{
    public class EnfermeirosFormViewModel
    {
        public Enfermeiro enfermeiro { get; set; }
        public List<Hospital> hospitais { get; set; }
    }
}
