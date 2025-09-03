using System;
namespace _2._5_CToFPart2{

    public class Program
    {
        static void Main(string[] args)
        {
        convertCtoF(45);
        }
        public static void convertCtoF(float c ){
            float f = c*(9/5)+32 ;
            Console.WriteLine("your degree in celcius:" +c);
            Console.WriteLine("your degree in fahren:" + f);
        }
    }

}