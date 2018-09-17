using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataValidator.Extensions
{
    public static class DateExtension
    {
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsHoliday(this DateTime date)
        {
            return date.IsFixedHoliday() || date.IsMobileHoliday();
        }

        private static bool IsFixedHoliday(this DateTime date)
        {
            string[] fixedHolidays =
                {
                    "01/01", // Ano novo
                    "21/04", // Tiradentes
                    "01/05", // Dia do trabalhador
                    "07/09", // Independência do Brasil
                    "12/10", // Padroeira do Brasil
                    "02/11", // Finados
                    "15/11", // Proclamação da Republica
                    "24/12", // Natal
                    "25/12", // Natal
                    "31/12"  // Ano novo
                };

            return fixedHolidays.Contains(date.ToString("dd/MM"));
        }

        private static bool IsMobileHoliday(this DateTime date)
        {
            var easterDate = GetEasterDate(date);
            var carnivalPeriod = GetCarvinalPeriod(easterDate);
            var crucifixionDate = GetCrucifixionDate(easterDate);
            var corpusCristiDate = GetCorpusCristiDate(easterDate);

            if (date == easterDate) return true;
            if (date >= carnivalPeriod[0] && date <= carnivalPeriod[1]) return true;
            if (date == crucifixionDate) return true;
            if (date == corpusCristiDate) return true;

            return false;
        }

        private static DateTime GetEasterDate(DateTime date)
        {
            var x = 0;
            var y = 0;

            var easterDate = DateTime.MinValue; // 1/1/0001 00:00:00
            easterDate = easterDate.AddYears(date.Year - 1);

            if (date.Year >= 1900 && date.Year <= 2099)
            {
                x = 24;
                y = 5;
            }
            else if (date.Year >= 2100 && date.Year <= 2199)
            {
                x = 24;
                y = 6;
            }
            else if (date.Year >= 2200 && date.Year <= 2299)
            {
                x = 25;
                y = 7;
            }

            int a = date.Year % 19;
            int b = date.Year % 4;
            int c = date.Year & 7;

            var d = ((19 * a) + x) % 30;
            var e = (((2 * b) + (4 * c) + (6 * d) + y)) % 7;

            if (d + e < 10)
            {
                easterDate = easterDate.AddDays(d + e + 21);
                easterDate = easterDate.AddMonths(2);
            }
            else
            {
                easterDate = easterDate.AddDays(d + e - 10);
                easterDate = easterDate.AddMonths(3);
            }

            if (easterDate.Day == 26 && easterDate.Month == 4)
                easterDate = easterDate.AddDays(-7);

            if ((easterDate.Day == 25 && easterDate.Month == 4) && (d == 28 && a > 10))
                easterDate = easterDate.AddDays(-7);

            return easterDate;
        }

        private static DateTime[] GetCarvinalPeriod(DateTime easterDate)
        {
            easterDate = easterDate.AddSeconds(1);
            var carnivalWednesday = easterDate.AddDays(-46);
            var carnivalMonday = carnivalWednesday.AddDays(-2);

            return new DateTime[] { carnivalMonday, carnivalWednesday };
        }

        private static DateTime GetCrucifixionDate(DateTime easterDate)
        {
            easterDate = easterDate.AddSeconds(1);
            return easterDate.AddDays(-2);
        }

        private static DateTime GetCorpusCristiDate(DateTime easterDate)
        {
            easterDate = easterDate.AddSeconds(1);
            return easterDate.AddDays(60);
        }
    }
}
