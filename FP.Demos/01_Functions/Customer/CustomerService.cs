using System.Collections.Generic;
using System.Linq;

namespace FP.Demos._01_Functions
{
    public class CustomerService
    {
        private static readonly List<Customer> Customers = new List<Customer>
        {
            new Customer("John", "Doe", "john.doe@centric.eu", 30),
            new Customer("John", "John", "jj@centric.eu", 18),
            new Customer("Harry", "Potter", "harry.potter@centric.eu", 20),
            new Customer("Oliver", "Twist", "oliver.twist@centric.eu", 25),
        };

        /// <summary>
        /// Get customer names using inline delegates in LINQ.
        /// </summary>
        public IEnumerable<string> GetCustomersNamesOverAge(int age)
        {
            return Customers
                .Where(c => c.Age > age)
                .OrderBy(c => c.Age)
                .Select(c => $"{c.FirstName} {c.LastName}")
                .ToList();
        }

        /// <summary>
        /// Get customer names using local functions (or class level functions) in LINQ,
        /// when we want to increase the readability.
        /// </summary>
        public IEnumerable<string> GetCustomersNamesOverAge2(int age)
        {
            bool HasAgeOver(Customer c) => c.Age > age;
            string ToFullName(Customer c) => $"{c.FirstName} {c.LastName}";

            return Customers
                .Where(HasAgeOver)
                .OrderBy(c => c.Age)
                .Select(ToFullName)
                .ToList();
        }
    }
}