using System;

namespace Password
{
    class Program
    {
        static int[] prox = new int[1000000]; 
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int size = input.Length;

            kmp(input);

            int inEnd = prox[size - 1];
            int flag = prox[inEnd];

            if (inEnd == -1)
                flag = -1;

            for (int i=1; i < (size -1); i++)
            {
                if (prox[i] == inEnd)
                    flag = inEnd;
            }

            if (flag == -1)
                Console.WriteLine("Just a legend");
            else
            {
                string output = input.Substring(0, flag + 1);
                Console.WriteLine(output);
            }
        }

        private static void kmp(string input)
        {
            int pos = -1;
            prox[0] = pos;

            for (int i = 1; i < input.Length; i++)
            {
                while (pos != -1 && input[i] != input[pos + 1])
                {
                    pos = prox[pos];
                }

                if (input[i] == input[pos + 1])
                {
                    pos++;
                    prox[i] = pos;
                }
                else
                    prox[i] = -1;
            }
        }
    }
}
