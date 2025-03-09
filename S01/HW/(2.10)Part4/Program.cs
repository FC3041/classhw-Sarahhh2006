using System;
namespace _2._10_Part4{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sin(45,0.001));
            Console.WriteLine(sin(90,0.001));
            Console.WriteLine(sin(0,0.001)); 
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
            public static double abs(double x){
                if(x>=0){
                    return x;
                }
                else{
                    return -x;
                }
            }
            public static double sin(double degree,double  precision){
                double sum=0;
                int n=1;
                double x=degree*(3.14/ 180);
                double summand = power(x,n)/fact(n);
                while(abs(summand)>=precision){
                    sum+=summand;
                    n+=2;
                    summand=(-summand*power(x,2))/(n*(n-1));;

                }
                return sum;
            }
    }
}