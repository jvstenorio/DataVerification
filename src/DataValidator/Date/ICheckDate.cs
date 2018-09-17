using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Date
{
    public interface ICheckDate
    {
        /// <summary>
        /// Validates and formats the date from a text
        /// </summary>
        /// <param name="text">Text containing the date string</param>
        /// <param name="format">Format of the date string to be returned</param>
        /// <returns></returns>
        DateResult ValidateAndFormatDate(string text, string format);
    }
}
