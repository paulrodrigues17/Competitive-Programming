using System;
using System.Collections.Generic;

namespace uva11572
{
    class Program
    {
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine());
            for (int i = 0; i < cases; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int[] snowflakes = new int[n];
                for (int j = 0; j < n; j++)
                    snowflakes[j] = int.Parse(Console.ReadLine());
                int max = 0;
                if (n > 0)
                {
                    IDictionary<int, int> map = new Dictionary<int, int>();
                    int[] aux = new int[n];
                    aux[0] = 1;
                    int start = 0;
                    map.Add(snowflakes[0], 0);

                    for (int j = 1; j < n; j++)
                    {
                        if (map.ContainsKey(snowflakes[j]))
                        {
                            int end = map[snowflakes[j]];
                            for (int k = start; k <= end; k++)
                                map.Remove(snowflakes[k]);
                            start = end + 1;
                            aux[j] = j - start + 1;
                        }

                        else
                            aux[j] = aux[j - 1] + 1;
                        map.Add(snowflakes[j], j);
                    }

                    foreach (int j in aux)
                        max = Math.Max(j, max);
                }
                Console.WriteLine(max);
            }
        }
    }
}
