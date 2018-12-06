using DataValidator.Date;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataValidator.Tests
{
    public class DateUnitTests
    {
        public ICheckDate checkDate { get; set; }

        [Theory]
        [InlineData("O natal esse ano acontece no dia 25/12/2018", "MM/dd/yyyy", true, false, "12/25/2018", true)]
        [InlineData("The D-Day happened on 6/6/1944", "dd/MM/yyyy", false, false, "06/06/1944", true)]
        [InlineData("Albert Einstein was born on 14/03/1879", "dd/MM/yyyy", false, false, "14/03/1879", true)]
        [InlineData("Só vou fazer isso dia 31/02/2019", "dd/MM/yyyy", false, false, "01/01/0001", false)]
        [InlineData("Não tem data aqui e agora", "dd/MM/yyyy", false, false, "", false)]
        public void TestCheckDate(string text, string format, bool isHoliday, bool isWeekend, string expectedOutput, bool isValid)
        {
            // Arrange
            checkDate = new CheckDate();

            // Act
            var result = checkDate.ValidateAndFormatDate(text, format);

            // Arrange
            result.IsHoliday.ShouldBe(isHoliday);
            result.IsWeekend.ShouldBe(isWeekend);
            result.Value.ShouldBe(expectedOutput);
            result.IsValid.ShouldBe(isValid);
        }
    }
}
