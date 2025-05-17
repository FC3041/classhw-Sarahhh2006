#include<iostream>
#include <math.h>

class Point
{
    public:
        double x;
        double y;

        Point(double t , double r){
            x= t;
            y=r;
        }
        Point(double w){
            x =w;
            y=w;
        }
        Point (Point* z){
            x=z->x;
            y=z->y;
        }
        Point (const Point& z){
            x=z.x;
            // z.y+=1;
            y=z.y;
        }
        ~Point(){
            cout << "x in d" << x<<"y ind d:"<<y<<endl;
        }
    void print_point(){
    cout << "x:" << x<< ", y:" << y<<endl;
    }
    double print_distance(Point w){
        double x_d = x - w.x;
        double y_d = y -w.y;
        return sqrt(x_d*x_d + y_d*y_d);
}

};
using namespace std;
int main(){
    Point p1(4,5);
    // p1.x = 4;
    // p1.y = 5;
    p1.print_point();
    Point p2(5,10);
    Point p3(p2);
    p3.print_point();
    // p1.x = 5;
    // p2.y= 10;
    cout<< p1.x << endl;
    int a ;
    std::cin>>a;
    std::cout<<"a:" <<a<<endl;

}

void print_point(Point p1){
    cout << "x:" << p.x<< ", y:" << p.y<<endl;
}

double print_distance(point p, Point w){
    double x_d = x.p - x.w;
    double y_d + p.y -p.w;
    return sqrt(x_d*x_d + y_d*y_d)
}