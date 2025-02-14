using System;
namespace _2._7_Part6{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(days_in_month(1));
        }

        public static int days_in_month(int mn)
        {
            if (mn == 1|| mn == 3 || mn == 5|| 
                mn == 7 || mn == 8 || mn == 10|| 
                mn == 12)
            {
                return 31;
            }
            else if (mn == 4|| mn == 6 || mn == 9 || 
                     mn == 11)
            {
                return 30;
            }
            else if (mn == 2)
            {
                return 28;
            }
            else{
                return 0;
            }
        }
    }
}
