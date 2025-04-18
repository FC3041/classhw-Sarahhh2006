using System;
namespace _2._10_Part1{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(eulers_constant(0.0001));
        }
        public static int fact(int n){
            
            if (n==1 || n==0)
            {
            return 1 ; 
            }
            // else if (n<0){
            //     return 0;
            // }
            else 
            {
                return n*fact(n-1);
            }
        }
        public static double eulers_constant(double precision){
            double sum =1;
            int n = 1; 
            double summand = 1/fact(n);
            while(summand>=precision){
                sum+=summand ;
                n++;
            }
            return sum;
        }
        
    }


}