using System;
using System.Linq;

class ktr
{
    private int[] tree;
    private int s;

    public ktr(int size)
    {
        this.s = size;
        this.tree = new int[size + 1];
    }

    public void u(int i, int v)
    {
        i++;
        while (i <= s)
        {
            tree[i] += v;
            i += i & -i;
        }
    }

    public int PrefixSum(int ix)
    {
        ix++;
        int t = 0;
        while (ix > 0)
        {
            t += tree[ix];
            ix -= ix & -ix;
        }
        return t;
    }

    public int kth(int k)
    {
        int position = 0, sum = 0;
        int maxBit = (int)Math.Floor(Math.Log2(s)) + 1;
        for (int i = maxBit; i >= 0; i--)
        {
            int nextPos = position + (1 << i);
            if (nextPos <= s && sum + tree[nextPos] < k)
            {
                position = nextPos;
                sum += tree[nextPos];
            }
        }
        return position;
    }

    public void Clear()
    {
        Array.Fill(tree, 0);
    }
}

class Solution
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int[] asd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] li = new int[num];
        ktr tree = new ktr(num);

        for (int i = 0; i < num; i++)
        {
            tree.u(i, 1);
        }

        for (int i = num - 1; i >= 0; i--)
        {
            int pos = tree.kth(asd[i]);
            li[pos] = i + 1;
            tree.u(pos, -1);
        }

        Console.WriteLine(string.Join(" ", li));
    }
}