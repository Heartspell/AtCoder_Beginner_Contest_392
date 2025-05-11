using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class F
{
    static readonly double p = Math.Acos(-1);

    public static void B(List<Complex> a)
    {
        int n = a.Count;
        int j = 0;
        for (int i = 1; i < n; i++)
        {
            int b = n >> 1;
            while ((j & b) != 0)
            {
                j ^= b;
                b >>= 1;
            }
            j ^= b;
            if (i < j)
                (a[i], a[j]) = (a[j], a[i]);
        }
    }

    public static void I(List<Complex> a, bool inv)
    {
        int n = a.Count;
        B(a);
        for (int l = 2; l <= n; l <<= 1)
        {
            double a1 = 2 * p / l * (inv ? -1 : 1);
            Complex w = new Complex(Math.Cos(a1), Math.Sin(a1));
            for (int i = 0; i < n; i += l)
            {
                Complex e = Complex.One;
                for (int j = 0; j < l / 2; j++)
                {
                    Complex u = a[i + j], v = a[i + j + l / 2] * e;
                    a[i + j] = u + v;
                    a[i + j + l / 2] = u - v;
                    e *= w;
                }
            }
        }
        if (inv)
        {
            for (int i = 0; i < n; i++)
                a[i] /= n;
        }
    }

    public static void J(List<Complex> a)
    {
        I(a, true);
    }

    public static List<long> C(List<int> a, List<int> b)
    {
        List<Complex> x = a.Select(i => new Complex(i, 0)).ToList();
        List<Complex> y = b.Select(i => new Complex(i, 0)).ToList();
        int n = 1;
        while (n < a.Count + b.Count)
            n <<= 1;
        x.AddRange(Enumerable.Repeat(new Complex(0, 0), n - x.Count));
        y.AddRange(Enumerable.Repeat(new Complex(0, 0), n - y.Count));

        I(x, false);
        I(y, false);
        for (int i = 0; i < n; i++)
            x[i] *= y[i];
        J(x);

        List<long> r = new List<long>(new long[n]);
        for (int i = 0; i < n; i++)
            r[i] = (long)Math.Round(x[i].Real);
        return r;
    }
}

class M
{
    public static long K(List<int> a)
    {
        int m = a.Max();
        List<int> f = Enumerable.Repeat(0, m + 1).ToList();
        foreach (int n in a)
            f[n] = 1;

        List<long> p = F.C(f, f);
        long r = 0;
        foreach (int n in a)
            if (2 * n < p.Count)
                r += (p[2 * n] - 1) / 2;
        return r;
    }

    public static long E(long a, long b, long c = 1000000007)
    {
        long r = 1;
        while (b > 0)
        {
            if ((b & 1) == 1)
                r = r * a % c;
            a = a * a % c;
            b >>= 1;
        }
        return r;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> a = Console.ReadLine().Split().Select(int.Parse).ToList();

        Console.WriteLine(K(a));
    }
}