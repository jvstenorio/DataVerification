using DataValidator.Cnpj;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Tests
{
    [TestFixture]
    public class CnpjUnitTests
    {
        private ICheckCnpj checkCnpj;

        [OneTimeSetUp]
        public void Config()
        {
            checkCnpj = new CheckCnpj();
        }

        [TestCase("oi meu cnpj eh esse daqui 325679210001-27", true, "32567921000127", "32.567.921/0001-27")]
        [TestCase("00000000000000000000032.567.921/0001-27", true, "32567921000127", "32.567.921/0001-27")]
        [TestCase("32.567.921/0001-27", true, "32567921000127", "32.567.921/0001-27")]
        [TestCase("36.732.527/0001-58", true, "36732527000158", "36.732.527/0001-58")]
        [TestCase("88.398.308/0001-88", true, "88398308000188", "88.398.308/0001-88")]
        [TestCase("67.613.129/0001-46", true, "67613129000146", "67.613.129/0001-46")]
        [TestCase("105340946-00", false, "", "")]
        [TestCase("02.526.904/0001-81", false, "02526904000181", "02.526.904/0001-81")]
        [TestCase("76.599.093/0001-85", false, "76599093000185", "76.599.093/0001-85")]
        [TestCase("11111111111111", false, "11111111111111", "11.111.111/1111-11")]
        [TestCase("banana", false, "", "")]
        [TestCase("opa é 249965000112", true, "00249965000112", "00.249.965/0001-12")]
        [TestCase("Meu Cnpj é 40015389000163", true, "40015389000163", "40.015.389/0001-63")]
        [TestCase("meu cnpj é 40.015.389/0001-63", true, "40015389000163", "40.015.389/0001-63")]
        [TestCase("CPF: 40.015.389/0001-63", true, "40015389000163", "40.015.389/0001-63")]
        [TestCase("oi boa noite meu cpf eh 40.015.389/0001-63", true, "40015389000163", "40.015.389/0001-63")]
        public void ExtractAndCheckCnpj_ShouldReturnCheckCnpj(string text, bool expectedResult, string expectedCnpj, string expectedFormatted)
        {
            // Arrange

            // Act
            var result = checkCnpj.ExtractAndCheckCnpj(text);

            // Arrange
            result.IsValid.ShouldBe(expectedResult);
            result.Identifier.ShouldBe(expectedCnpj);
            result.Formatted.ShouldBe(expectedFormatted);
        }
    }
}
