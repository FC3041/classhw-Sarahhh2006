using System;
using System.Diagnostics;
namespace _2._10_Part6{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(squareroot(2,2, 0.001));
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
        public static double squareroot(double x,int y,double precision)
        {
            double lowerb=0;
            double upperb=x;
            Debug.Assert(x>=1);
            double mid=(lowerb+upperb)/2;
            int iter=0;
            while((upperb-lowerb)>=precision)
            {
                mid=(lowerb+upperb)/2;
                double midy=power(mid, y);
                if(midy<x)
                {
                    lowerb=mid;
                }
                else
                {
                    upperb= mid;
                }
                iter++;
            }
            return mid;
        }
    }
}