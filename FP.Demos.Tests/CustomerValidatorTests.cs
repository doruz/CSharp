using System.Collections.Generic;
using FluentAssertions;
using FP.Demos._01_Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FP.Demos.Tests
{
    [TestClass]
    public class CustomerValidatorTests
    {
        [TestMethod]
        public void When_ValidatingCustomer_Should_ReturnValidationMessagesForAllProperties()
        {
            var customer = new Customer("", null, null, 10);

            var result = ValidateCustomer(customer);

            result.Should().BeEquivalentTo(
                "1. First Name is required",
                "2. Last Name is required",
                "3. Email is required",
                "4. Age must be over 16"
            );
        }

        [TestMethod]
        public void When_ValidatingCustomer_Should_ReturnValidationMessagesForEmailAndAge()
        {
            var customer = new Customer("John", "Doe", "test", 10);

            var result = ValidateCustomer(customer);

            result.Should().BeEquivalentTo(
                "1. Email must end with @email.com",
                "2. Age must be over 16"
            );
        }

        [TestMethod]
        public void When_ValidatingCustomer_Should_ReturnNoValidationMessages()
        {
            var customer = new Customer("John", "Doe", "test@email.com", 16);

            var result = ValidateCustomer(customer);

            result.Should().BeEmpty();
        }

        private List<string> ValidateCustomer(Customer customer)
            => new CustomerValidator().GetValidationErrors(customer);
    }
}
