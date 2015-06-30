using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 3, 4, 7, 1, 8, 10, 21, 5, 9, 11, 14, 19 };

            var result = FilterData(numbers, x => x > 7);

            result.ToList().ForEach(Console.WriteLine);

            Console.ReadLine();
        }

        private static IEnumerable<int> FilterData(IEnumerable<int> numbers, Func<int, bool> filter)
        {
            foreach (var number in numbers)
            {
                if (filter(number))
                {
                    yield return number;
                }
            }
        }

        private static bool IsEven(int number)
        {
            return number%2 == 0;
        }

        private static bool GreaterThanSeven(int number)
        {
            return number > 7;
        }

    }
}
