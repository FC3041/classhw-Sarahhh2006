using System;
namespace _2._7_Part2{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fact(5));
        }
        public static int fact(int n){
            if (n==1 || n==0)
            {
            return 1 ; 
            }
            else if (n<0){
                return 0;
            }
            else 
            {
                return n*fact(n-1);
            }
        }
    }
}