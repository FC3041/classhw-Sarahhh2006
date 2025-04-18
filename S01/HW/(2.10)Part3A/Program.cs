using System;
namespace _2._10_Part3A{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(near(-2,3,0.01));
        }
        public static int abs(int x){
            if(x>=0){
                return x;
            }
            else{
                return -x;
            }
        }
        public static bool near(int x, int y, double closeness){
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
                if (differnce<=closeness*max)
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