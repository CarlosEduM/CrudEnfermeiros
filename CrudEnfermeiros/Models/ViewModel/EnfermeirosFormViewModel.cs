using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudEnfermeiros.Models.ViewModel
{
    public class EnfermeiroFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "{0} é obrigatorio")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "{0} deve ter entre {2} e {1}")]
        public string NomeCompleto { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} é obrigatorio")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} deve ter {1} numeros")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "{0} deve conter apenas numeros")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "{0} é obrigatorio")]
        [Display(Name = "COREN")]
        public string Coren { get; set; }

        [Required(ErrorMessage = "{0} é obrigatorio")]
        [DataType(DataType.Date)]
        public DateTime DataDeNasciento { get; set; }
        public int HospitalId { get; set; }
        public ICollection<Hospital> Hospitais { get; set; }

        public EnfermeiroFormViewModel()
        {
        }

        public EnfermeiroFormViewModel(Enfermeiro enfermeiro, ICollection<Hospital> hospitais)
        {
            this.Id = enfermeiro.Id;
            this.NomeCompleto = enfermeiro.NomeCompleto;
            this.Cpf = enfermeiro.Cpf;
            this.Coren = enfermeiro.Coren;
            this.DataDeNasciento = enfermeiro.DataDeNasciento;
            this.HospitalId = enfermeiro.HospitalId;
            this.Hospitais = hospitais;
        }

        public EnfermeiroFormViewModel(ICollection<Hospital> hospitais)
        {
            this.Hospitais = hospitais;
        }

        public Enfermeiro ToEnfermeiro()
        {
            return new Enfermeiro
            {
                Id = this.Id,
                NomeCompleto = this.NomeCompleto,
                Cpf = this.Cpf,
                Coren = this.Coren,
                DataDeNasciento = this.DataDeNasciento,
                HospitalId = this.HospitalId,
                Hospital = null
            };
        }
    }
}
