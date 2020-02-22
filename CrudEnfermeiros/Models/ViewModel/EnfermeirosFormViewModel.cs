using System.Collections.Generic;

namespace CrudEnfermeiros.Models.ViewModel
{
    public class EnfermeirosFormViewModel
    {
        public Enfermeiro Enfermeiro { get; set; }
        public ICollection<Hospital> Hospitais { get; set; }
    }
}
