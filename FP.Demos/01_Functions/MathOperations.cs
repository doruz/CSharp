using System;

namespace FP.Demos._01_Functions
{
    public static class MathOperations
    {
        public static int Evaluate(this string expression)
        {
            var elements = expression.Split(' ');
            var left = int.Parse(elements[0]);
            var operation = elements[1];
            var right = int.Parse(elements[2]);

            return Evaluate(left, operation, right);
        }

        private static int Evaluate(int left, string operation, int right)
        {
            switch (operation)
            {
                case "+":
                    return Add(left, right);
                case "-":
                    return Subtract(left, right);
                case "*":
                    return Multiply(left, right);
                case "/":
                    return Divide(left, right);
                default:
                    throw new NotSupportedException("The supplied operator is not supported");
            }
        }

        private static int Add(int left, int right)
        {
            return left + right;
        }

        private static int Subtract(int left, int right)
        {
            return left - right;
        }

        private static int Multiply(int left, int right)
        {
            return left * right;
        }

        private static int Divide(int left, int right)
        {
            return left / right;
        }
    }
}
