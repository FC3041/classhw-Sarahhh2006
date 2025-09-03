using System.Numerics;

public class ComplexNumber<T> where T : INumber<T>
{
    public T Real;
    public T Img;
    public ComplexNumber(T R, T img)
    {
        Real = R;
        Img = img;
    }
    public override string ToString()
    {
        return $"{Real}+{Img}i";
    }

    // baraye jam az interface inumber bayad estefade kone 
    public static ComplexNumber<T> operator +(ComplexNumber<T> a, ComplexNumber<T> b)
    {
        return new ComplexNumber<T>(a.Real + b.Real, a.Img + b.Img);
    }
}

// why + operator method static ?
//You're not calling a method on a or b. You're asking the compiler
//  to resolve the + operator between two operands. That resolution happens via a static method defined in the class.