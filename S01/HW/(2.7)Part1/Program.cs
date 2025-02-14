using System;
namespace _2._7_Part1{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(absolute_value(-100));
            Console.WriteLine(absolute_value(-1));
            Console.WriteLine(absolute_value(0));
            Console.WriteLine(absolute_value(1));
            Console.WriteLine(absolute_value(1000));
        }
    public static int  absolute_value(int x){
        if (x>=0){
            return x ;}
        else {
            return -x ;}
    }
    }
}