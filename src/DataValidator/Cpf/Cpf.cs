using System;

namespace DataValidator.Cpf
{
    public class Cpf
    {
        public Cpf(string cpf, bool isValid)
        {
            Identifier = cpf ?? string.Empty;
            Formatted = !(string.IsNullOrEmpty(cpf)) ? FormatCpf(cpf) : string.Empty;
            IsValid = isValid;
        }

        private string FormatCpf(string cpf)
        {
            var formatted = string.Empty;
            var tokens = cpf.ToCharArray();
            formatted = $"{cpf.Substring(0,3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
            return formatted;
        }

        /// <summary>
        /// Full CPF number, unformatted
        /// </summary>
        public string Identifier { get; }
        /// <summary>
        /// Full CPF number using format XXX.XXX.XXX-XX
        /// </summary>
        public string Formatted { get; }
        /// <summary>
        /// Boolean indicating if the CPF string is valid or not
        /// </summary>
        public bool IsValid { get; }
    }
}
