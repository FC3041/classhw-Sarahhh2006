using System;
namespace _2._10_Part3{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(exp2(1,0.01));
        }
        public static double sin(double x, double precision){
            double sum = 1;
            int n=1;
            double summand = x/n;
            while(summand>=precision){
                sum+=summand;
                n++;
                summand*=x/n;

            }
            return sum; 
        }
    }

}