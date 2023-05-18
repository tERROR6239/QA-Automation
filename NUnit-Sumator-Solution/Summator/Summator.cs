namespace Summator
{
    public static class Summator
    {
        public static int Sum(int[] arr)  //long
        { 
        int sum = arr[0]; //int sum = 0;
            for (int i = 1; i < arr.Length; i++) //i = 0;
            {
                sum += arr[i];
                
            }
        return sum;     
        }

        public static int Average(int[] arr)  //long
        {
            int sum = 0; 
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

            }
            return sum/arr.Length;
        }


    }
} 
