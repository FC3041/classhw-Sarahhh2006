

using System.Collections;

namespace S13;

class Program
{
    public static void printPerson(IPerson<int>[] o ){
        foreach(var p in o){
             System.Console.WriteLine(p);
    }}
    // public static void ProntPerson(Student s){
    //     System.Console.WriteLine(s.FullName);
    // }

    // public static void ProntPerson(Teacher t){
    //     System.Console.WriteLine(t.FullName);
    // }
    // we dont want repititive code we use get/set as a method in an interface
    static void Main(string[] args)
    {
    //    Student s = new Student(){
    //     FirstName = "sarah",
    //     Lname="ahmadi",
    //    };

        Student[] students = new Student[]{ new Student(){
            FirstName="sarah",
            Lname = "Ahmadi",
            GPA = 18,
            ID=12
        },

        new Student(){
            FirstName="Saba",
           Lname="shayegan",
           GPA = 20,
           ID=5

        },
         new Student(){
            FirstName="sarina",
           Lname="Farahani",
           GPA = 17,
           ID=4

        },






    //    Teacher t = new Teacher(){
    //     FirstName= "saba",
    //     Lname = "Shayegan ",
    //    };


    };

    printPerson(students);
    System.Console.WriteLine("--------");
    // Array.Sort(students);
    Mysort(students, PersonComparers.IDComparer);
    printPerson(students );
    Mysort(students, PersonComparers.fullnamecomparer);
    System.Console.WriteLine("--------");
    printPerson(students );


    }
    private static void Mysort(IPerson<int>[] persons , IComparer<IPerson<int>> cmp )
    {
        for(int i =0;i<persons.Length ; i++){
            for(int j=i+1 ; j<persons.Length ; j++){
                // if(persons[i].CompareTo(persons[j])>0){
                //     swap(persons , i , j );
                // }
                if (cmp.Compare(persons[i], persons[j]) > 0)
                    swap<IPerson<int>>(persons, i, j);
            }
        }
    }

    private static void swap<T> (T[] items, int i , int j )
    {
        T temp = items[i];
        items[i] = items[j];
        items[j] = temp;
    }

}
