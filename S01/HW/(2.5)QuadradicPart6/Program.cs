using System;
namespace _2._5_QuadradicPart6{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the value of A: ");
            double A = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the value of B: ");
            double B = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the value of C: ");
            double C = Convert.ToDouble(Console.ReadLine());
            Double root1 , root2 ;  
            double delta = (B*B) - (4*A*C);
            if (delta>0)
            {
                root1 = (-B + Math.Sqrt(delta) )/ 2.0*A ; 
                root2 = (-B - Math.Sqrt(delta) )/ 2.0*A ;
                Console.WriteLine(("root 1 and root2 " + root1 + root2));
            }
            else if (delta== 0)
            {
                root1 = -B / 2*A ; 
                Console.WriteLine("the only root is" + root1) ;
            }
            else
            {
                Console.WriteLine("there is no root in set of real numbers");
            }

        }
    }
}