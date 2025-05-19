using System.Diagnostics;

namespace _2._10_Part7{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ln(2, 0.001));
        }
        public static double ln(double x,double precision)
        {
            double lowerb= 0;
            double upperb=x;
            Debug.Assert(x>=1);
            double mid=(lowerb+upperb)/2;
            while ((upperb-lowerb)>= precision)
            {
                mid=(lowerb+upperb)/2;
                if (exp(mid,precision)<x)
                {
                    lowerb=mid;
                }
                else
                {
                    upperb=mid;
                }
            }
            return mid;
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