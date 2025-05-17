namespace S11con;

class Program
{
    static void Method4()
    {
        System.Console.WriteLine("in method 4 enter");
        throw new FileNotFoundException();
        System.Console.WriteLine("in method 4 exit");
    }    

    static void Method3()
    {
        System.Console.WriteLine("in method 3 enter");
        Method4();
        System.Console.WriteLine("in method 3 exit");
    }
    static void Method2()
    {
        System.Console.WriteLine("in method 2 enter");
        try
        {
            Method3();
        }
        catch(Exception e)
        {
            System.Console.WriteLine($"in catch method 2 \n{e.StackTrace}");
            throw;
        }
        System.Console.WriteLine("in method 2 exit");
    }
    static void Method1()
    {
        System.Console.WriteLine("in method 1 enter");
        Method2();
        System.Console.WriteLine("in method 1 exit");
    }


    static void Main(string[] args)
    {
        System.Console.WriteLine("in main enter");
        try
        {
            Method1();
        }
        catch(Exception e)
        {
            System.Console.WriteLine($"in catch main \n{e.StackTrace}");
        }
        System.Console.WriteLine("in main exit");
    }
    static void Main33(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Student S = new Student( fname: "Sarah" , lname: "Ahmadi" , 
        ID : 471111122, StdID : 40340929 , GPA: 18);
        List<Student> students = new List<Student>();
        students.Add(S);
        students.Add( new Student(fname: "Saba"  , lname: "Shayegan"  , 
        ID : 471111122, StdID : 4034929 , GPA: 20));
        // foreach(Student mm in students){
        //     System.Console.WriteLine(mm);
        // }
        // students.Sort();
        // System.Console.WriteLine("------------");
        // foreach(Student mm in students){
        //     System.Console.WriteLine(mm);
        // }
        int sum = 0;
        // int loopCount ; 
        while (true ){
            System.Console.WriteLine("enter a number :");
            try{
            int n = int.Parse(Console.ReadLine());
            sum+=n;
            System.Console.WriteLine($"thnx for entring number {n}");
            System.Console.WriteLine($"sum divided by n is {sum/n}");

            }
            catch(OverflowException){

            }
            catch(Exception e){
                System.Console.WriteLine($"error . Try again {e.Message}");
            }
            // catch(FormatException fe){
            //     System.Console.WriteLine($"{fe.Message} , try again ");
            //     continue;
            // }


        }
    }
}

