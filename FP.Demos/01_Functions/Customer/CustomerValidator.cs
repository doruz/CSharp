using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FP.Demos._01_Functions
{
    public class CustomerValidator
    {
        public bool IsValidCustomer(Customer customer)
        {
            return GetValidationRules(customer).All(validation => validation() != null);
        }

        public List<string> GetValidationErrors(Customer customer)
        {
            return GetValidationRules(customer)
                .Select(validate => validate())
                .Where(error => error != null)
                .Select((error, index) => $"{index + 1}. {error}")
                .ToList();
        }

        private List<Func<string>> GetValidationRules(Customer customer) => new List<Func<string>>
        {
            () => ValidateRequired(customer.FirstName)("First Name"),
            () => ValidateRequired(customer.LastName)("Last Name"),
            () => ValidateRequired(customer.Email)("Email") ?? ValidateEmail(customer.Email),
            () => ValidateAge(customer.Age),
            () => SomeExpensiveValidation(customer)
        };

        private Func<string, string> ValidateRequired(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return property => $"{property} is required";
            }

            return _ => null;
        }

        private string ValidateEmail(string value)
        {
            var emailSuffix = "@email.com";

            if (!value.EndsWith(emailSuffix))
            {
                return $"Email must end with {emailSuffix}";
            }

            if (value.Length - emailSuffix.Length < 4)
            {
                return $"Email address must have at least {emailSuffix.Length + 4} in length";
            }

            return null;
        }

        private string SomeExpensiveValidation(Customer customer)
        {
            Thread.Sleep(new Random().Next(1000, 2000));

            return null;
        }

        private string ValidateAge(int age)
            => age < 16 ? "Age must be over 16" : null;
    }
}