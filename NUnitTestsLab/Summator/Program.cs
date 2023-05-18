using System;

namespace Summator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = SummatorApp.Sum(new int[] {1,2,3,4,5, });
            if (sum == 21)
            {
                Console.WriteLine("TEST SUM PASS");
            }
            else
            {
                Console.WriteLine("TEST SUM FAIL");
            }
            
           
        }
    }
}
