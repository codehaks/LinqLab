using MoreLinq;
using System;
using System.Linq;

namespace LinqLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestZip();

        }

        static void TestZip()
        {
            int[] v1 = { 1, 2, 3 };
            int[] v2 = { 5, 6, 7 };

            var r=v1.Zip(v2, (a, b) => a * b);

            r.ForEach((x) =>
            {
                Console.WriteLine(x);
            });
        }
    }
}
