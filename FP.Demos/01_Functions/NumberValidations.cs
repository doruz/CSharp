using System;
using System.Collections.Generic;
using System.Linq;

namespace FP.Demos._01_Functions
{
    /*
    * A number is valid if all conditions from below are met:
    * 1 - to be positive
    * 2 - to be a multiple of 2
    * 3 - to be less than 100
    */
    public class NumberValidations
    {
        public const string IsNegative = "IS_NEGATIVE";
        public const string IsNotDivisibleBy2 = "IS_NOT_DIVISIBLE_BY_2";
        public const string IsHigherThan100 = "IS_HIGHER_THEN_100";

        /// <summary>
        /// Validate number using if logic.
        /// </summary>
        public IEnumerable<string> ValidateNumber(int number)
        {
            if (number < 0)
            {
                yield return IsNegative;
            }

            if (number % 2 != 0)
            {
                yield return IsNotDivisibleBy2;
            }

            if (number > 100)
            {
                yield return IsHigherThan100;
            }
        }

        /// <summary>
        /// Validate number using a dictionary with (validation key, validation logic).
        /// </summary>
        public IEnumerable<string> ValidateNumber2(int number)
        {
            var validations = new Dictionary<string, bool>
            {
                [IsNegative] = number < 0,
                [IsNotDivisibleBy2] = number % 2 != 0,
                [IsHigherThan100] = number > 100,
            };

            return validations
                .Where(pair => pair.Value)
                .Select(pair => pair.Key);
        }

        /// <summary>
        /// Validate number using list of (validation key, validation logic) tuples.
        /// </summary>
        public IEnumerable<string> ValidateNumber3(int number)
        {
            var allValidations = new (string key, bool isInvalid)[]
            {
                ( IsNegative, number < 0 ),
                ( IsNotDivisibleBy2, number % 2 != 0 ),
                ( IsHigherThan100, number > 100 ),
            };

            return allValidations
                .Where(pair => pair.isInvalid)
                .Select(pair => pair.key);
        }
    }
}
