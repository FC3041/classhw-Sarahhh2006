using System;
namespace _2._4_TrianglesPart1{

    public class Program
    {
        static void Main(string[] args)
        {
        print_left_triangle(20);
        }
        public static void print_left_triangle(int b){
            for(int i=1 ; i<=b ; i++){
                for(int j=0 ; j<i ; j++){
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        
    }



}