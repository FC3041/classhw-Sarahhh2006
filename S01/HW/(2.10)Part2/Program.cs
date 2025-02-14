using System;
namespace _2._10_Part2{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(exp(1,0.01));
        }
        public static double power(double x , int y)
        {
            double res =1;
            if (y>0){
                for(int i =1 ; i<=y ;i++){
                    res*= x ;
                }
                return res;
            }
            else if (y==0){
                return 1;
            }
            else{
                return 0;
            }
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
        public static double exp(double x,double  precision){
            double sum=1+x;
            int n=2;
            double summand = power(x,n)/fact(n);
            while(summand>=precision){
                sum+=summand;
                n++;
                summand=power(x, n)/fact(n);

            }
            return sum;
        }

    }
}