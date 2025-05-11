using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] A = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i != j)
                {
                    int k = 3 - i - j; 
                    if (A[i] * A[j] == A[k])
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
            }
        }
        Console.WriteLine("No");
    }
}