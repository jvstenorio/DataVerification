using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.PhoneNumber
{
    public class PhoneNumber
    {
        public PhoneNumber(string number, bool isValid)
        {
            Number = number;
            IsValid = isValid;
            RegionCode = string.Empty;
            FullNumber = string.Empty;
        }

        /// <summary>
        /// Boolean indicating if the phone number is valid or not (considering number of digits only)
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Phone number extracted (without regional code)
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Regional code extracted
        /// </summary>
        public string RegionCode { get; set; }

        /// <summary>
        /// Full phone number, including regional code
        /// </summary>
        public string FullNumber { get; set; }
    }
}
