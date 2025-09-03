namespace Caesar;

class Program
{
    static void Main(string[] args)
    {
        //     Console.WriteLine("Hello, World!");
        string s = "adkfksAxz";
        string s1 = s.Encoder();
        // string s2 = s.Decoder();
        System.Console.WriteLine(s1);
        System.Console.WriteLine(s1.Decoder());
    }
}
