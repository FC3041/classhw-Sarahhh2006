using System;
namespace _2._5_AverageOfSquaresPart7{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(average_of_squares0(5));
        }
        public static double average_of_squares0(int n){
            double sum = 0;
            for(int i=0 ; i<n;i++){
                sum+=i*i;
            }
            return sum/(n-1);
        }
    }
}