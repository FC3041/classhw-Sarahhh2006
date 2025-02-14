using System;
using System.Diagnostics;
namespace _2._10_Part3B{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(exp(1, 0.001));
            Console.WriteLine(exp2(1, 0.001));
            Debug.Assert(near(exp(1, 0.001),exp2(1, 0.001), 0.001));
        }
        public static double exp2(double x, double precision){
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
                summand=power(x,n)/fact(n);

            }
            return sum;
        }
        public static double abs(double x){
            if(x>=0){
                return x;
            }
            else{
                return -x;
            }
        }
        public static bool near(double x, double y, double closeness){
        double max;
        if (abs(y) > abs(x))
        {
            max = abs(y);
        }
        else
        {
            max = abs(x);
        }
        double differnce = abs(x-y);
        while (true)
            {
                if (differnce<= closeness * max)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}