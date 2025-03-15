using System;
namespace _2._7_Part8{

    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(days_before_date(2014, 1, 1));
            Console.WriteLine(days_before_date(2014, 12, 31));
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
        public static int days_before_date(int year, int monthnum, int daynum)
        {
            int daysbefo = 0;
            for (int m=1; m< monthnum; m++)
            {
                daysbefo += days_in_month(m);
            }
            daysbefo+= daynum- 1;
            return daysbefo;
        }
    }
}

