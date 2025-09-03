namespace HW;

class Program
{
    static void Printinfo(ItranFactors t)
        {
            System.Console.WriteLine("---");
            Console.WriteLine($"Cost:{t.cost()}");
            Console.WriteLine($"size: {t.size()}");
            Console.WriteLine($"safety: {t.safety()}");
            Console.WriteLine($"environmental impact: {t.enviroImpact()}");
        }
    static void Main(string[] args)
    {
        Cars myCar=new Cars(4.5, 2.0, 1.5);
            Bus citybus= new Bus(15.0, 5.5, 3.0);
            Airplane airp= new Airplane(70.0, 60.0, 20.0);
            Printinfo(myCar);
            Printinfo(citybus);
            Printinfo(airp);
    }
}
