using System;
using System.Text;

namespace Period
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            int input = 1;
            StringBuilder sb = new StringBuilder();

            while (t-- > 0)
            {
                int n = int.Parse(Console.ReadLine());
                string str = Console.ReadLine();

                sb.Append("Test case #" + input + "\n");
                kmp(str, sb);
                input++;
            }
            Console.WriteLine(sb);
        }

        private static void kmp(string str, StringBuilder sb)
        {
            int len = str.Length;
            int[] lps = new int[len];
            lps[0] = 0;
            int j = 0;
            int i = 1;

            for (i=1; i < len; i++)
            {
                if (str[i].Equals(str[j]))
                {
                    j++;
                    lps[i] = j;
                }
                else
                {
                    while (true)
                    {
                        if (j == 0 || str[j].Equals(str[i]))
                            break;
                        j = lps[j - 1];
                    }

                    if (str[j].Equals(str[i]))
                    {
                        j++;
                        lps[i] = j;
                    }
                    else
                        lps[i] = 0;
                }

                if (lps[i] == 0)
                    continue;
                int ans = i + 1 - lps[i];
                if ((i + 1) % ans != 0)
                    continue;

                int ans1 = i + 1;
                int ans2 = (i + 1) / ans;
                sb.Append(ans1 + " " + ans2 + "\n");
            }
        }
    }
}
