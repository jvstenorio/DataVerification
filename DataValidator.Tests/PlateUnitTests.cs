using DataValidator.Plate;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataValidator.Tests
{
    public class PlateTests
    {
        public ICheckPlate checkPlate { get; set; }

        [Theory]
        [InlineData("Minha placa é ABC1234", "ABC1234", true, PlateTypes.Brazil)]
        [InlineData("Eu troquei minha placa pro padrão mercosul, ela agora eh ABC1D23", "ABC1D23", true, PlateTypes.Mercosul)]
        [InlineData("Minha placa é abc-1234", "ABC1234", true, PlateTypes.Brazil)]
        [InlineData("Eu troquei minha placa pro padrão mercosul, ela agora eh ABC-1D23", "ABC1D23", true, PlateTypes.Mercosul)]
        [InlineData("Minha placa é ABCd1234", "", false, PlateTypes.Unknown)]
        [InlineData("Eu troquei minha placa pro padrão mercosul, ela agora eh ABCD123", "", false, PlateTypes.Unknown)]
        [InlineData("Minha placa é abc 1234", "ABC1234", true, PlateTypes.Brazil)]
        [InlineData("Eu troquei minha placa pro padrão mercosul, ela agora eh ABC 1D23", "ABC1D23", true, PlateTypes.Mercosul)]
        public void TestCheckPlate(string text, string extracted, bool isValid, PlateTypes plateType)
        {
            // Arrange
            checkPlate = new CheckPlate();

            // Act
            var result = checkPlate.ExtractAndCheckPlate(text);

            // Arrange
            result.FullPlate.ShouldBe(extracted);
            result.IsValid.ShouldBe(isValid);
            result.PlateType.ShouldBe(plateType);
        }
    }
}
