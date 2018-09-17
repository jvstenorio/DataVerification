using DataValidator.PhoneNumber;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidator.Tests
{
    [TestFixture]
    public class PhoneNumberUnitTests
    {
        public ICheckPhoneNumber checkPhoneNumber;

        [OneTimeSetUp]
        public void Config()
        {
            checkPhoneNumber = new CheckPhoneNumber();
        }

        [Test]
        [TestCase("meu telefone é +55031986619392 vlw", true, "+55031", "986619392", "+55031986619392")]
        [TestCase("meu telefone é +55 031 9866-19392 vlw", true, "+55031", "986619392", "+55031986619392")]
        [TestCase("me liga no +5531986619392 vlw", true, "+5531", "986619392", "+5531986619392")]
        [TestCase("me liga no +5531 98661-9392 vlw", true, "+5531", "986619392", "+5531986619392")]
        [TestCase("me chama no zap 986619392", true, "", "986619392", "986619392")]
        [TestCase("me chama no zap 31986619392 vlw", true, "31", "986619392", "31986619392")]
        [TestCase("me chama no zap 031986619392 vlw", true, "031", "986619392", "031986619392")]
        [TestCase("me chama no zap 86619392 vlw", false, "", "", "")]
        [TestCase("me chama no zap 8661-9392 vlw", false, "", "", "")]
        public void ExtractAndValidatePhoneNumber(string text, bool isValid, string expectedRegionCode, string expectedNumber, string expectedFullNumber)
        {
            // Arrange

            // Act
            var result = checkPhoneNumber.ValidatePhoneNumber(text);

            // Arrange
            result.FullNumber.ShouldBe(expectedFullNumber);
            result.FullNumber.ShouldBe(expectedRegionCode+expectedNumber);
            result.IsValid.ShouldBe(isValid);
            result.Number.ShouldBe(expectedNumber);
            result.RegionCode.ShouldBe(expectedRegionCode);
        }
    }
}
