using System;
using System.Collections.Generic;

namespace FP.Demos._01_Functions
{
    public static class MathOperations2
    {
        private delegate int MathOperation(int left, int right);

        public static int Evaluate(this string expression)
        {
            var elements = expression.Split(' ');
            var left = int.Parse(elements[0]);
            var operation = elements[1];
            var right = int.Parse(elements[2]);

            return GetOperationUsingFunc(operation)(left, right);
        }

        /// <summary>
        /// Get operation using custom delegate and local functions for each operation.
        /// </summary>
        private static MathOperation GetOperationUsingCustomDelegate(string operation)
        {
            int Add(int left, int right) => left + right;
            int Subtract(int left, int right) => left - right;
            int Multiply(int left, int right) => left * right;
            int Divide(int left, int right) => left / right;

            var operations = new Dictionary<string, MathOperation>
            {
                {"+", Add},
                {"-", Subtract},
                {"*", Multiply},
                {"/", Divide},
            };

            return operations[operation];
        }

        /// <summary>
        /// Get operation using delegates and local functions.
        /// </summary>
        private static Func<int, int, int> GetOperationUsingFunc(string operation)
        {
            var operations = new Dictionary<string, Func<int, int, int>>
            {
                ["+"] = (left, right) => left + right,
                ["-"] = (left, right) => left - right,
                ["*"] = (left, right) => left * right,
                ["/"] = (left, right) => left / right,
            };

            return operations[operation];
        }
    }
}
