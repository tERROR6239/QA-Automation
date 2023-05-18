using System;

namespace Summator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Summator.Sum(new int[] { 1,2,3,4,5,6, }));
            int sum = Summator.Sum(new int[] { 1, 2, 3, 4, 5, 6 });
            if (sum == 21)
            {
                Console.WriteLine("TEST SUM PASS");
            } else 
            { 
                Console.WriteLine("TEST SUM FAIL");
            }

            int avarage = Summator.Average(new int[] { 1, 2, 3, 4, 5, 6 });
            if (avarage == 3)
            {
                Console.WriteLine("TEST AVERAGE PASS");
            }
            else
            {
                Console.WriteLine("TEST AVERAGE FAIL");
            }
        }
    }
}
