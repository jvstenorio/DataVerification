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
        public bool IsValid { get; set; }
        public string Number { get; set; }
        public string RegionCode { get; set; }
        public string FullNumber { get; set; }
    }
}
