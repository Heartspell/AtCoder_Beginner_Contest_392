using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var asd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int N = asd[0], M = asd[1];
        var A = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
        var missing = new List<int>();
        for (int i = 1; i <= N; i++)
        {
            if (!A.Contains(i))
            {
                missing.Add(i);
            }
        }
        Console.WriteLine(missing.Count);
        if (missing.Count > 0)
        {
            Console.WriteLine(string.Join(" ", missing));
        }
    }
}