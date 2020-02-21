using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEnfermeiros.Models
{
    public class Enfermeiro
    {
        public int Id { get; set; }
        public string NameCompleto { get; set; }
        public string Cpf { get; set; }
        public string Coren { get; set; }
        public DateTime DataDeNasciento { get; set; }
        public Hospital Hospital { get; set; }

        public bool ValidarCpf()
        {
            int[] mat = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mat2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };


            // verificando primeiro digito
            int result = 0;

            for(int i = 0; i < mat.Length; i++)
            {
                result += mat[i] * int.Parse($"{Cpf[i]}");
            }

            result %= 11;

            if(result < 2)
            {
                result = 0;
            }
            else
            {
                result = 11 - result;
            }

            if(result != int.Parse($"{Cpf[9]}"))
            {
                return false;
            }

            // verificando o segundo digito
            result = 0;

            for (int i = 0; i < mat2.Length; i++)
            {
                result += mat2[i] * int.Parse($"{Cpf[i]}");
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

            if (result != int.Parse($"{Cpf[10]}"))
            {
                return false;
            }

            return true;
        }
    }
}
