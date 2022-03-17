using System;

namespace Trigalge
{
    class Test
    {
        static double a;
        static double b;
        static double c;
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                String[] tokens = Console.ReadLine().Split();
                a = double.Parse(tokens[0]);
                b = double.Parse(tokens[1]);
                c = double.Parse(tokens[2]);

                bisection(0, 1000000);
            }
        }

        private static void bisection(double a, double b)
        {
            if (func(a) * func(b) >= 0)
                return;

            double mid = a;
            while ((b - a) >= 0.000001)
            {
                mid = (a + b) / 2;
                if (func(mid) == 0.0)
                    break;
                else if (func(mid) * func(a) < 0)
                    b = mid;
                else
                    a = mid;
            }

            string output = string.Format("{0:0.######}", mid);
            Console.WriteLine(output);
            //Console.WriteLine();
        }

        private static double func(double x)
        {
            return a * x + b * Math.Sin(x) - c;
        }
    }
}
