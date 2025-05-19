namespace S16;

class Program
{
    static void Main(string[] args)
    {
        Citizen k = new Citizen("sam", "Ahmadi", 1, true ,123);
        Student s = new Student(
            "saba", "Hedayati", 245,false,1234,"cs", 403521, false);
        GradStudent gs = new GradStudent(
            "Pari", "Hedayati", 2,false,456, "Math", 403521, false,
            "Calculus", "Integral");
        

        System.Console.WriteLine(k);
        System.Console.WriteLine(s);
        //The derived class inherits the overridden version from the base class.override base class ro ejra mikkone .agar naneveshte bashim .
        //agar implement karde bashim male khodesho unless base.ToString() is explicitly called).
        Citizen[] citizens = new Citizen[]{k, s, gs};
        s.Register("Numericals");
        gs.Register("Numericals 2");
        //it will write the name of the class because it hasnt got override to string 
    }
}
