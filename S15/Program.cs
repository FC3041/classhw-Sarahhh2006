using System.Numerics;

namespace S15;

class Program
{
    // static T Max<T>(T a,T b){
    //     where T: IComparable<T>
    //     {
    //         if (a.Compareto)
    //     }

    // };

    static T sum<T>(T a, T b) where T : INumber<T>
    {
        return a+b;

    }

    
}
