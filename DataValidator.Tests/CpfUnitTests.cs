using DataValidator.Cpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;
using Xunit;

namespace DataValidator.Tests
{
    //[TestFixture]
    public class CpfUnitTests
    {
        private ICheckCpf checkCpf;

        [Theory]
        [InlineData("000000002985278635", true, "02985278635", "029.852.786-35")]
        [InlineData("00000000000", false, "00000000000", "000.000.000-00")]
        [InlineData("000.000.000-00", false, "00000000000", "000.000.000-00")]
        [InlineData("0000000000010234896577", false, "10234896577", "102.348.965-77")]
        [InlineData("banana", false, "", "")]
        [InlineData("meu cpf é 11540093603", true, "11540093603", "115.400.936-03")]
        [InlineData("CPF: 115.400.936-03", true, "11540093603", "115.400.936-03")]
        [InlineData("CPF: 2985278635", true, "02985278635", "029.852.786-35")]
        [InlineData("oi boa noite meu cpf eh 105.340.946-00", true, "10534094600", "105.340.946-00")]
        [InlineData("be7cacd5-9abd-44c4-8149-468dc9231d89-guid-de-bot-1a2s3_01234567890@0mn.io", true, "01234567890", "012.345.678-90")]
        [InlineData("00000000000000001234567890", true, "01234567890", "012.345.678-90")]
        [InlineData("Meu CPF: 004 665 739/87 . Solicitei o fornecimento do medicamento Lynparza em 25/06/18 através de e-mail para central.saude. Peço verifica como está esse processo.", true, "00466573987", "004.665.739-87")]
        public void ExtractAndCheckCpf(string text, bool expectedResult, string expectedCpf, string expectedFormatted)
        {
            // Arrange
            checkCpf = new CheckCpf();

            // Act
            var result = checkCpf.ExtractAndCheckCpf(text);

            // Arrange
            result.IsValid.ShouldBe(expectedResult);
            result.Identifier.ShouldBe(expectedCpf);
            result.Formatted.ShouldBe(expectedFormatted);
        }
    }
}
