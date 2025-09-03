using System;
namespace _2._5_AverageOfSquaresPart8{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(average_of_squares1(5));
            Console.WriteLine(average_of_squares1(4));
            if (average_of_squares0(5) == average_of_squares1(4))
            {
                Console.WriteLine("they are the same ");
            }
            else
            {
                Console.WriteLine("they are not the same ");
        }
        }
        public static double average_of_squares1(int n){
            double sum = 0;
            for(int i=1 ; i<=n;i++){
                sum+=i*i;
            }
            return sum/n;
        }
        static double average_of_squares0(int n)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += i * i;
            }
            return sum / n;
        }
    }
}