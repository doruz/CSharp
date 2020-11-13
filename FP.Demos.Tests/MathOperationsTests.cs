using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FP.Demos.Tests
{
    using static FP.Demos._01_Functions.MathOperations2;

    [TestClass]
    public class MathOperationsTests
    {
        [TestMethod]
        public void When_AddExpressionIsProvided_Should_ReturnCorrectResult()
        {
            var result = "6 + 2".Evaluate();

            result.Should().Be(8);
        }

        [TestMethod]
        public void When_SubtractExpressionIsProvided_Should_ReturnCorrectResult()
        {
            var result = "6 - 2".Evaluate();

            result.Should().Be(4);
        }

        [TestMethod]
        public void When_MultiplyExpressionIsProvided_Should_ReturnCorrectResult()
        {
            var result = "6 * 2".Evaluate();

            result.Should().Be(12);
        }

        [TestMethod]
        public void When_DivideExpressionIsProvided_Should_ReturnCorrectResult()
        {
            var result = "6 / 2".Evaluate();

            result.Should().Be(3);
        }

        [TestMethod]
        public void When_UnknownExpressionIsProvided_Should_ThrowException()
        {
            Action result = () => "6 & 2".Evaluate();

            result.Should().Throw<Exception>();
        }
    }
}
