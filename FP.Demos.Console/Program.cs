using System;
using System.Threading;
using FP.Demos._01_Functions;

namespace FP.Demos.Console
{
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            //TestExpressions();

            Instrumentation.Time("Validate Customer", TestCustomerValidation);
            Instrumentation.Time("Validate Customer", DoSomeExpensiveOperation);

            WriteLine();
        }

        private static void TestExpressions()
        {
            WriteLine($"1 + 1 = {MathOperations.Evaluate("1 + 1")}");
            WriteLine($"2 - 1 = {MathOperations.Evaluate("2 - 1")}");
            WriteLine($"2 * 2 = {MathOperations.Evaluate("2 * 2")}");
            WriteLine($"6 / 2 = {MathOperations.Evaluate("6 / 2")}");
        }

        private static void TestCustomerValidation()
        {
            var customer = new Customer("", null, null, 10);

            new CustomerValidator()
                .GetValidationErrors(customer)
                .ForEach(WriteLine);
        }

        private static void DoSomeExpensiveOperation()
        {
            Thread.Sleep(new Random().Next(1000, 5000));
        }
    }
}
