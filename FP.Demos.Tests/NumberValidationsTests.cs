using System.Collections.Generic;
using FluentAssertions;
using FP.Demos._01_Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FP.Demos.Tests
{
    [TestClass]
    public class NumberValidationsTests
    {
        [TestMethod]
        public void When_MinusOne_IsVerified_Should_ShouldReturnValidationErrors()
        {
            var result = Act(-1);

            result.Should().BeEquivalentTo(NumberValidations.IsNegative, NumberValidations.IsNotDivisibleBy2);
        }

        [TestMethod]
        public void When_0_IsVerified_Should_ShouldReturnValidationErrors()
        {
            var result = Act(0);

            result.Should().BeEmpty();
        }

        [TestMethod]
        public void When_2_IsVerified_Should_ShouldReturnWithoutValidationErrors()
        {
            var result = Act(2);

            result.Should().BeEmpty();
        }

        [TestMethod]
        public void When_3_IsVerified_Should_ShouldReturnValidationErrors()
        {
            var result = Act(3);

            result.Should().BeEquivalentTo(NumberValidations.IsNotDivisibleBy2);
        }

        [TestMethod]
        public void When_100_IsVerified_Should_ShouldReturnWithoutValidationErrors()
        {
            var result = Act(100);

            result.Should().BeEmpty();
        }

        [TestMethod]
        public void When_101_IsVerified_Should_ShouldReturnValidationErrors()
        {
            var result = Act(101);

            result.Should().BeEquivalentTo(NumberValidations.IsNotDivisibleBy2, NumberValidations.IsHigherThan100);
        }

        [TestMethod]
        public void When_102_IsVerified_Should_ShouldReturnValidationErrors()
        {
            var result = Act(102);

            result.Should().BeEquivalentTo(NumberValidations.IsHigherThan100);
        }

        private IEnumerable<string> Act(int number)
            => new NumberValidations().ValidateNumber3(number);
    }
}
