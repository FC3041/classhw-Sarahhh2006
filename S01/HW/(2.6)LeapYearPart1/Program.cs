using System;
namespace _2._6_LeapYearPart1{

    public class Program
    {
        static void Main(string[] args)
        {
            int[] years ={ 1792, 1796, 1800, 1804, 1900, 1904, 2000, 2004 };
            for (int i=0; i<8;i++){
                int year = years[i];
                Console.WriteLine(is_leap_year(year));
            }
        }
        public static bool is_leap_year(int year){
            if (year%400==0 || year%4==0 && year%100 !=0){
                return true;
            }
            else{
                return false;
            }
        }
    }
}