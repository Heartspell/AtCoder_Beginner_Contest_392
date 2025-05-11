using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        var asd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var zxc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var qwe = new int[N + 1];
        for (int i = 0; i < N; i++)
        {
            qwe[i + 1] = zxc[i];
        }
        var result = new int[N];
        for (int i = 0; i < N; i++)
        {
            int personStaringAt = asd[i];         
            result[zxc[i] - 1] = qwe[personStaringAt];
        }
        Console.WriteLine(string.Join(" ", result));
    }
}