using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<float> numbers = new List<float>();

        numbers.Add(3.5f);
        numbers.Add(-1.2f);
        numbers.Add(7.8f);
        numbers.Add(-5f);

        Console.WriteLine("Danh sách các số:");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        numbers.Sort();

        Console.WriteLine("\nDanh sách sau khi sắp xếp:");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}