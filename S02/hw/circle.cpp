#include <iostream>
#include <cmath>
using namespace std;

class point{
    public:
    double x;
    double y;
};

class circle{
    public:
    double radius ;
    double centerx;
    double centery;
    circle(double x ,double y,double r){
        centerx=x;
        centery=y;
        radius=r;
    }
    double Area(){
        return M_PI*radius*radius;}
    double perimeter(){
        return M_PI*2*radius;
    }
    double circlesDis(const circle& d){
        double disC = sqrt((centerx -d.centerx)*(centerx -d.centerx)+(centery-d.centery)*(centery-d.centery));
        return disC;
    }
    double pointDis(const point& d){
        double disP = sqrt((centerx -d.x)*(centerx -d.x)+(centery-d.y)*(centery-d.y));
        return disP;
    }
    bool checkInOrOut(point a){
        if (pointDis(a)<=radius){
            return true;
        }
        else return false;
    }

};

int main(){
    circle circle1(5,8,3);
    circle circle2(4,9,8);
    point x;
    x.x=4;
    x.y=8;
    cout << "mohit dayere aval: " << circle1.Area() << endl;
    cout << "masahat dayere aval:" <<circle1.perimeter() << endl;
    cout << "faseleye do dayere:"<< circle1.circlesDis(circle2)<< endl;
    cout << "faselye noghte az dayere:" << circle1.pointDis(x) << endl;
    cout << "check in whether point is inside the circle1 or not:"<< circle1.checkInOrOut(x)<< endl;

}