namespace S12;

class Program
{
    public static void MySort<T>(T[] plist) where T: IhasHigher<T>
    {
        for(int i=0; i<plist.Length;i++)
        {
            for(int j=i+1; j<plist.Length;j++)
            {
                if(plist[i].IsHigher(plist[j]))
                {
                    swap(plist, i, j);
                }
            }
        }
    }

    private static void swap<T>(T[] plist, int i, int j)
    {
        T temp = plist[i];
        plist[i] = plist[j];
        plist[j] = temp;
    }

    static void Main(string[] args)
    {
        Student[] students = new Student[3]{
            new Student("maryam","akbari", 1233),
            new Student("zoha", "saberi", 1531),
            new Student("narges", "hosseini", 1009)
        };

        for(int i=0; i<students.Length;i++)
            students[i].PrintStudent();
        
        System.Console.WriteLine("------------------------");

        MySort(students);

        for(int i=0; i<students.Length;i++)
            students[i].PrintStudent();

        Teacher[] teachers = new Teacher[3]{
            new Teacher("maryam","akbari", 1233),
            new Teacher("zoha", "saberi", 1531),
            new Teacher("narges", "hosseini", 1009)
        };

        for(int i=0; i<teachers.Length;i++)
            teachers[i].PrintStudent();
        
        System.Console.WriteLine("------------------------");

        MySort(teachers);

        for(int i=0; i<teachers.Length;i++)
            teachers[i].PrintStudent();



    }
    static void Mann(string[] args ){
        People p1 = new People("sarah" , "ahamdi" ,471167) ; 
         People p2= new People("saba" , "shayegan" , 4030493);
         People p3 = new People("Aryana","khalili" , 3492) ; 
        List<People> people = new List<People>();
        people.Add(p1);
        people.Add(p2);
        people.Add(p3);
        for(int i=0; i<people.Count() ;i++){
            System.Console.WriteLine(people[i].Name);
        }

        people.Sort();

        for(int i=0; i<people.Count() ;i++){
            System.Console.WriteLine(people[i].Name);
        }


    }
    static void Mai0(string[] args)
    {
        IShape[] shapes = new IShape[]{
            new Rectangle(2,3),
            new Circle(8),
        };

        double pSum=0;
        double ASum=0;

        for(int i =0 ; i<shapes.Length;i++){
            pSum +=shapes[i].Peerimeter();
            ASum += shapes[i].Area();
        }
        // using(MyTimer t = new MyTimer("sum of numbers from 0 to 20")){
        //     int sum =0;
        //     for(int i =0;i<20 ;i++){
        //         sum+=i;
        //     }
        //     System.Console.WriteLine(sum);
        // }
    }
}
