using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DataValidator.Cpf
{
    public class CheckCpf : ICheckCpf
    {
        private const string CpfRegex = @"((\d|\s|\-|\.)*\d?\d?\d(\s|\-|\.)*\d\s*\d\s*\d(\s|\-|\.)*\d\s*\d\s*\d(\s|\-|\.|\/)*\d\s*\d(^\d)*)";
        private readonly Regex _rgx;

        public CheckCpf()
        {
            _rgx = new Regex("^[0-9]+$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Returns if a CPF string is valid or not
        /// </summary>
        /// <param name="cpf">CPF string to be validated</param>
        /// <returns></returns>
        public bool IsValid(string cpf)
        {
            cpf = ExtractCpf(cpf);

            if (!_rgx.IsMatch(cpf)) return false;

            int[] digits = cpf.Select(x => int.Parse(x.ToString())).ToArray();

            int val1 = 10, val2 = 11;

            int validador1 = 0, validador2 = 0;

            return (!digits.All(x => x == digits.First())) && //Verifica se todos os números são iguais
                (digits[9] == ((validador1 = (digits.Take(9).Sum(x => x * val1--) % 11)) < 2 ? 0 : 11 - validador1)) && //Verifica se o primeiro digito verificador está correto
                    (digits[10] == ((validador2 = (digits.Take(10).Sum(x => x * val2--) % 11)) < 2 ? 0 : 11 - validador2)); //Verifica o segundo digito verificador
        }

        /// <summary>
        /// Returns the extracted CPF value from input text and if it's valid or not
        /// </summary>
        /// <param name="text">Text containing the CPF to be extracted.</param>
        /// <returns></returns>
        public Cpf ExtractAndCheckCpf(string text)
        {
            var regex = CpfRegex;
            var coll = Regex.Matches(text, regex);
            if (coll.Count <= 0 || coll[0].Groups.Count <= 0)
                return new Cpf(string.Empty, false);
            var result = coll[0].Groups[0].Value;

            return new Cpf(ExtractCpf(result), IsValid(result));
        }

        private static string ExtractCpf(string cpf)
        {
            cpf = cpf.Replace("/", "").Replace(".", "").Replace("-", "").Replace(" ", "").TrimStart('0').PadLeft(11, '0');
            return cpf;
        }
    }
}
