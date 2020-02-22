using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEnfermeiros.Models
{
    public class Hospital
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} é obrigatorio")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "{0} deve ter o tamanho entre {2} e {1}")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "{0} é obrigatorio")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "{0} deve ter o tamanho entre {2} e {1}")]
        public string Endereco { get; set; }


        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "{0} é obrigatorio")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "{0} deve conter somente números")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "{0} deve ter {1} numeros")]
        public string Cnpj { get; set; }

        public bool validarCnpj()
        {
            int[] mat = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mat2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // verificando o primeiro digito
            int result = 0;

            for (int i = 0; i < mat.Length; i++)
            {
                result += mat[i] * int.Parse($"{Cnpj[i]}");
            }

            result %= 11;

            if (result < 2)
            {
                result = 0;
            }
            else
            {
                result = 11 - result;
            }

            if (result != int.Parse($"{Cnpj[12]}"))
            {
                return false;
            }

            // verificando o segundo digito
            result = 0;

            for (int i = 0; i < mat2.Length; i++)
            {
                result += mat2[i] * int.Parse($"{Cnpj[i]}");
            }

            result %= 11;

            if (result < 2)
            {
                result = 0;
            }
            else
            {
                result = 11 - result;
            }

            if (result != int.Parse($"{Cnpj[13]}"))
            {
                return false;
            }

            return true;
        }
    }
}
