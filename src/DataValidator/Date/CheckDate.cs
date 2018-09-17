using DataValidator.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace DataValidator.Date
{
    public class CheckDate : ICheckDate
    {
        /// <summary>
        /// Validates and formats the date from a text
        /// </summary>
        /// <param name="text">Text containing the date string</param>
        /// <param name="format">Format of the date string to be returned</param>
        /// <returns></returns>
        public DateResult ValidateAndFormatDate(string text, string format)
        {
            var toReturn = new DateResult("", false);

            var dateSplitted = Regex.Split(text, @"\D+").Where(x => x != string.Empty).ToArray();

            if (dateSplitted.Length > 2)
            {
                var isValid = DateTime.TryParse($"{dateSplitted[2]}-{dateSplitted[1]}-{dateSplitted[0]}", out DateTime dateTime);

                toReturn.IsValid = isValid;

                if (isValid)
                {
                    toReturn.Value = dateTime.ToString(format);
                    toReturn.Age = GetAge(dateTime);
                    toReturn.IsHoliday = dateTime.IsHoliday();
                    toReturn.IsWeekend = dateTime.IsWeekend();
                }
                else
                {
                    toReturn.Value = dateTime.ToString(format);
                    toReturn.Age = null;
                    toReturn.IsHoliday = false;
                    toReturn.IsWeekend = false;
                }
            }

            return toReturn;
        }

        private DateResult ValidateDate(string text)
        {
            var result = new DateResult("", false);

            var numbersWithSpace = Regex.Replace(text, "\\D+", " ");
            var dateArray = numbersWithSpace.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (dateArray.Length == 3)
            {
                try
                {
                    var date = new DateTime(int.Parse(dateArray[2]), int.Parse(dateArray[1]), int.Parse(dateArray[0]));
                    result.Value = date.ToString("yyyy-MM-dd");
                    result.IsValid = true;
                    result.Age = GetAge(date);
                    result.IsHoliday = date.IsHoliday();
                    result.IsWeekend = date.IsWeekend();

                }
                catch (Exception e)
                {

                }

            }

            return result;
        }

        private int GetAge(DateTime bornDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bornDate.Year;

            if (bornDate > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
