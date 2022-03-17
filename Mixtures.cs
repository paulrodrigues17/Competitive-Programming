using System;
using System.Text;

namespace Mixtures
{
    class Program
    {
        static long[,] dp;
        static int[] arr;
        static void Main(string[] args)
        {
            while (true)
            {
                string st = Console.ReadLine();
                if (string.IsNullOrEmpty(st)) break;
                int n = int.Parse(st);
                arr = new int[n];
                dp = new long[n, n];
                String[] tokens = Console.ReadLine().Split();

                for (int i = 0; i < n; i++)
                    arr[i] = int.Parse(tokens[i]);

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        dp[i, j] = long.MaxValue;
                int size = n - 1;
                Console.WriteLine(mcm(0, size));
            }
        }

        private static long mcm(int i, int j)
        {
            if (i >= j) return 0;
            if (dp[i, j] != long.MaxValue) return dp[i, j];

            long ans = dp[i, j];

            for (int k = i; k < j; k++)
            {
                ans = Math.Min(ans, mcm(i, k) + mcm(k + 1, j) + getSum(i, k) * getSum(k + 1, j));
            }

            dp[i, j] = ans;
            return ans;
        }

        private static long getSum(int i, int j)
        {
            long sum = 0;

            for (int k = i; k <= j; k++)
            {
                sum += arr[k];
                sum %= 100;
            }

            return sum;
        }
    }
}
