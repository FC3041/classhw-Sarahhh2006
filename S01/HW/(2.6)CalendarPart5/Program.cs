using System;
namespace _2._6_CalendarPart5{

    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 12; i++)
        {
            print_month(i);
        }
        }
    public static void print_month(int monthnum)
    {
        if (monthnum < 1 || monthnum > 12)
        {
            return;
        }
        string[] months = {
            "january", "febuary", "march", "april", "may", "june",
            "july", "august", "september", "octubary", "november", "december"
        };
        Console.WriteLine(months[monthnum - 1]);
    }
}}

