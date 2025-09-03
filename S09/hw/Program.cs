using System;
namespace hw;

class Program
{
    static void Main(string[] args)
    {
        string filee = "students.csv";
            while(true)
            {
                Console.WriteLine("enter info:\n");
                Console.Write("name:");
                string name = Console.ReadLine();
                Console.Write("stu id:");
                int stdid = int.Parse(Console.ReadLine());
                Console.Write("national iD:");
                int natid = int.Parse(Console.ReadLine());
                Console.Write("credits:");
                int credits = int.Parse(Console.ReadLine());
                Console.Write("active:");
                bool active = bool.Parse(Console.ReadLine());
                Student student = new Student(name, stdid, natid, credits, active);
                File.AppendAllLines(filee, new string[] { student.ToString() });
            
            Console.WriteLine("\nregistered ones:");
            if (File.Exists(filee))
            {
                string[] lines = File.ReadAllLines(filee);
                foreach (var l in lines)
                {
                    var stu = Student.Parse(l);
                    Console.WriteLine($"name:{stu.name},stu id: {stu.stdid}, national id: {stu.natid},credits: {stu.credits}, active: {stu.active}");
                }
            }
        }}
}

