using DataValidator.Plate;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Tests
{
    [TestFixture]
    public class PlateTests
    {
        public ICheckPlate checkPlate { get; set; }

        [OneTimeSetUp]
        public void Config()
        {
            checkPlate = new CheckPlate();
        }

        [Test]
        [TestCase("Minha placa é ABC1234", "ABC1234", true)]
        [TestCase("Eu troquei minha placa pro padrão mercosul, ela agora eh ABC1D23", "ABC1D23", true)]
        [TestCase("Minha placa é abc-1234", "ABC1234", true)]
        [TestCase("Eu troquei minha placa pro padrão mercosul, ela agora eh ABC-1D23", "ABC1D23", true)]
        [TestCase("Minha placa é ABCd1234", null, false)]
        [TestCase("Eu troquei minha placa pro padrão mercosul, ela agora eh ABCD123", null, false)]
        [TestCase("Minha placa é abc 1234", "ABC1234", true)]
        [TestCase("Eu troquei minha placa pro padrão mercosul, ela agora eh ABC 1D23", "ABC1D23", true)]
        public void TestCheckDate(string text, string extracted, bool isValid)
        {
            // Arrange

            // Act
            var result = checkPlate.ExtractAndCheckPlate(text);

            // Arrange
            result.FullPlate.ShouldBe(extracted);
            result.IsValid.ShouldBe(isValid);
        }
    }
}
