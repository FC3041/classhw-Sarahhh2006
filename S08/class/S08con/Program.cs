namespace S08con;

public class Program
{
    public static int add(int a,int b){
        return a+b;
    }
    public static void reverse(string s, out string revere){
        revere = "";
        foreach(char c in s){
            revere =c+ revere;
        }
    }
    public static void reversesen(string s , out string revsen){
        string revsen ="";
    }
    static void Main(string[] args)
    {
        // for(int i =0; i<args.Length ;i++){
        //     Console.WriteLine($"args{i} : {args[i]}")
        // }
        // Console.WriteLine("Hello, World!");
        int sum =0;
        while(true){
            System.Console.WriteLine("nums?");
            string s = Console.ReadLine();
            if(string.IsNullOrEmpty(s)){
                break;
            }
            int n ;
            if(! int.TryParse(s , out n)){
                Console.WriteLine("Wrong Try again later ");
                continue;
            }
            sum +=int.Parse(s);
        }
    }

}
