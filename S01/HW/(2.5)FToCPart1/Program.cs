using System;
namespace _2._5_FToCPart1{

    public class Program
    {
        static void Main(string[] args)
        {
        convertCtoF(60);
        }
        public static void convertCtoF(float f ){
            float c= (f-32)*5/9;
            Console.WriteLine("your degree in celcius:" +c);
            Console.WriteLine("your degree in fahren:" + f);
        }
    }

}