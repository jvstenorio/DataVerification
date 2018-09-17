using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Cnpj
{
    public class Cnpj
    {
        public Cnpj(string cnpj, bool isValid)
        {
            Identifier = cnpj ?? string.Empty;
            IsValid = isValid;
            Formatted = !string.IsNullOrEmpty(cnpj) ? FormatCnpj(cnpj) : string.Empty;
        }

        private string FormatCnpj(string cnpj)
        {
            var formatted = string.Empty;
            formatted = $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
            return formatted;
        }

        /// <summary>
        /// Full CNPJ Number, unformatted
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// Boolean indicating if the CNPJ string is valid or not
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// Full CNPJ Number, formatted using format XX.XXX.XXX/XXXX-XX
        /// </summary>
        public string Formatted { get; set; }
    }
}
