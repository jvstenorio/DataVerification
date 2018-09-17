using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Date
{
    public class DateResult
    {
        /// <summary>
        /// Extracted and formatted date using format given
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Boolean indicating if date is valid or not
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Age, in years, of the extracted date
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Boolean indicating if set date is a weekend or not
        /// </summary>
        public bool? IsWeekend { get; set; }

        /// <summary>
        /// Boolean indicating if set date is a holiday or not
        /// </summary>
        public bool? IsHoliday { get; set; }

        public DateResult(string value, bool isValid)
        {
            Value = value;
            IsValid = IsValid;
            Age = null;
            IsWeekend = false;
            IsHoliday = false;
        }

    }
}
