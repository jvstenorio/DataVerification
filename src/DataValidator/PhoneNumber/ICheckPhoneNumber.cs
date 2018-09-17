using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.PhoneNumber
{
    public interface ICheckPhoneNumber
    {
        PhoneNumber ValidatePhoneNumber(string input);
    }
}
