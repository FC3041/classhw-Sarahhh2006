// See https://aka.ms/new-console-template for more information
using System.Numerics;

Console.WriteLine("Hello, World!");

// public static class Basic
// {
//     public static void Swap<T>(ref T a, ref T b)
//     {
//         T temp = a;
//         a = b;
//         b = temp;
//     }

// }
public class Basic
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}

public class ComplexNumber<T> where T : INumber<T>
    //gharare jam beshn 
{
    public T Real;
    public T Img;
    public ComplexNumber(T real, T img)
    {
        Real = real;
        Img = img;
    }
    public override string ToString()
    {
        return $"{Real}+{Img}i";
    }

    public static ComplexNumber<T> operator +(ComplexNumber<T> a, ComplexNumber<T> b)
    {
        return new ComplexNumber<T>(a.Real + b.Real, a.Img + b.Img);
    }
    
    }

public abstract class Developer
{
    public string name;
    public bool IsFemale;

    public Developer(string n, bool IsF)
    {
        this.name = n;
        this.IsFemale = IsF;
    }

    public string Name
    {
        get
        {
            return (IsFemale ? "خانم " : "آقای ") + this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public abstract int Salary { get; }
}