﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEnfermeiros.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }

        public bool validarCnpj()
        {
            int[] mat = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mat2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // verificando o primeiro digito
            int result = 0;

            for (int i = 0; i < mat.Length; i++)
            {
                result += mat[i] + Convert.ToInt32(Cnpj[i]);
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

            if (result != Cnpj[12])
            {
                return false;
            }

            // verificando o segundo digito
            result = 0;

            for (int i = 0; i < mat2.Length; i++)
            {
                result += mat2[i] + Convert.ToInt32(Cnpj[i]);
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

            if (result != Cnpj[13])
            {
                return false;
            }

            return true;
        }
    }
}