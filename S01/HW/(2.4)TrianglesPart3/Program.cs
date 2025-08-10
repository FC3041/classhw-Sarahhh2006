using System;
namespace _2._4_TrianglesPart3{

    public class Program
    {
        static void Main(string[] args)
        {
        print_left_triangle(20);
        }
        public static void print_left_triangle(int b){
            for(int i=1 ; i<=b ; i++){
                int m = b-i;
                for(int j=0 ; j<m ; j++){
                    Console.Write(" ");
                }
                for(int k =0 ;k<i;k++){
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        
    }



}