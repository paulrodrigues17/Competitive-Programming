using System;


namespace uva11286
{
    class Test
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = int.Parse(Console.ReadLine());
                if (n == 0)
                    break;

                long[] frosh = new long[n];
                for (int i = 0; i < n; i++)
                {
                    String[] tokens = Console.ReadLine().Split();
                    int[] line = new int[5];
                    for (int j = 0; j < 5; j++)
                        line[j] = int.Parse(tokens[j]);
                    Array.Sort(line);
                    long c = 0;
                    for (int j = 0; j < 5; j++)
                        c = c * 1000 + line[j];
                    frosh[i] = c;
                }

                Array.Sort(frosh);
                long tmp = frosh[0];
                int count = 1;
                int maxCount = 0;
                int ans = 0;
                for (int i = 1; i < n; i++)
                {
                    if (tmp == frosh[i])
                        count++;
                    else
                    {
                        tmp = frosh[i];
                        if (maxCount == count)
                            ans += count;
                        else if (maxCount < count)
                        {
                            ans = count;
                            maxCount = count;
                        }
                        count = 1;
                    }
                }

                if (maxCount == count)
                    ans += count;
                else if (maxCount < count)
                    ans = count;
                Console.WriteLine(ans);
            }
        }
    }
}
