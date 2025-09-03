using System;
namespace _2._4_TrianglesPart2{

    public class Program
    {
        static void Main(string[] args)
        {
        print_left_triangle(20 , '^');
        }
        public static void print_left_triangle(int b , char ch){
            for(int i=1 ; i<=b ; i++){
                for(int j=0 ; j<i ; j++){
                    Console.Write(ch);
                }
                Console.WriteLine();
            }
        }
        
    }



}