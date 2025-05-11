using System;
using System.Collections.Generic;

class Solution
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] q = new int[N];
        List<Dictionary<int, int>> li = new List<Dictionary<int, int>>();

        for (int i = 0; i < N; i++)
        {
            string[] asd = Console.ReadLine().Split(); 
            q[i] = int.Parse(asd[0]); 
            li.Add(new Dictionary<int, int>());

            for (int j = 1; j <= q[i]; j++) 
            {
                int a = int.Parse(asd[j]);
                if (li[i].ContainsKey(a))
                    li[i][a]++;
                else
                    li[i][a] = 1;
            }
        }

        double qwe = 0;

        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                double pro = 0;
                if (li[i].Count < li[j].Count)
                {
                    foreach (var face in li[i])
                    {
                        if (li[j].ContainsKey(face.Key))
                            pro += (double)face.Value / q[i] * li[j][face.Key] / q[j];
                    }
                }
                else
                {
                    foreach (var face in li[j])
                    {
                        if (li[i].ContainsKey(face.Key))
                            pro += (double)face.Value / q[j] * li[i][face.Key] / q[i];
                    }
                }
                qwe = Math.Max(qwe, pro);
            }
        }

        Console.WriteLine($"{qwe:F12}");
    }
}