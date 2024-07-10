using System;
using System.Collections.Generic;

namespace Bài42
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>{ 5, 3, 9, 1};

            numbers.Sort();
            numbers.Reverse();
            numbers.Insert(2, 7);
            numbers.Remove(9);
            numbers.RemoveAt(0);
            bool containNine = numbers.Contains(9);

            foreach (int i in numbers) {
                Console.WriteLine(i);
            }

            Console.WriteLine("Contain 9: "+ containNine);
        }
    }
}
