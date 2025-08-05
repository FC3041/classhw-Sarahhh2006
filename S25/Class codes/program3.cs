using System.Text.RegularExpressions;
using System.ComponentModel;

namespace S25;

class Program
{
    static void Main(string[] args)
    {
        using var client = new HttpClient();
        //using is for the disposablity of httpclient 
        string result = client.GetStringAsync("https://www.digikala.com/").Result;
        File.WriteAllText("index.html", result);
        // System.Console.WriteLine(result);
    }
}