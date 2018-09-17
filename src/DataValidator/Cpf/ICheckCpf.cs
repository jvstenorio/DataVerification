using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Cpf
{
    public interface ICheckCpf
    {
        /// <summary>
        /// Returns if a CPF string is valid or not
        /// </summary>
        /// <param name="cpf">CPF string to be validated</param>
        /// <returns></returns>
        bool IsValid(string cpf);

        /// <summary>
        /// Returns the extracted CPF value from input text and if it's valid or not
        /// </summary>
        /// <param name="text">Text containing the CPF to be extracted.</param>
        /// <returns></returns>
        Cpf ExtractAndCheckCpf(string text);
    }
}
