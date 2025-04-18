public interface IShape{
    public double Area();
    public Double Peerimeter();
}

class Rectangle:IShape{
    public double l ;
    public double w;

    public Rectangle(double ll, double ww) {
        l = ll;
        w = ww;
    }

    public double Area()
    {
        return l*w;
    }

    public double Peerimeter()
    {
        return 2*(l*w);
    }
}

public class Circle:IShape{
    public double radius ; 
    public Circle(double r ){
        radius = r; 
    }

    public double Area()
    {
        return Math.PI*radius*radius;
    }

    public double Peerimeter()
    {
        return Math.PI*2*radius;
    }
}