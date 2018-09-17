using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.PhoneNumber
{
    public interface ICheckPhoneNumber
    {
        /// <summary>
        /// Extracts and validates a phone number from text using Brazil's mask
        /// </summary>
        /// <param name="input">Text to search phone number on</param>
        /// <returns></returns>
        PhoneNumber ValidatePhoneNumber(string input);
    }
}
