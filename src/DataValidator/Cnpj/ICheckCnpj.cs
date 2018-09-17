using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Cnpj
{
    public interface ICheckCnpj
    {
        /// <summary>
        /// Returns if a CNPJ string is valid or not
        /// </summary>
        /// <param name="cnpj">CNPJ string to be validated</param>
        /// <returns></returns>
        bool isValid(string cnpj);
        /// <summary>
        /// Returns the extracted CNPJ value from input text and if it's valid or not
        /// </summary>
        /// <param name="text">Text containing the CNPJ to be extracted.</param>
        /// <returns></returns>
        Cnpj ExtractAndCheckCnpj(string text);
    }
}
