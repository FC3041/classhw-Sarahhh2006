#include<iostream>
#include<Windows.h>
using namespace std;
class mystring{
    public:
    char* string ;
    int size(const char* anotherstr){
        int count =0;
        int i =0;
        while(anotherstr[i] !='\0'){
            count++;
            string[i]=anotherstr[i];
            i++;
        }
        return count;
    }
    mystring(const char* anotherstr)
    {
        int size1= size(anotherstr);
        for(int i=0;i<=size1;i++){
            string[i]=anotherstr[i];
        }
        string[size1+1]='\0';
    }
};
class KeepTime{
    public:
    // mystring(m_function);
    unsigned long long start;
    unsigned long long finish;
    KeepTime(const mystring& function){
        start= GetTickCount64();
    }
    ~KeepTime(){
        finish= GetTickCount64();
        cout<< "zaman masraf shode bar hasb mili sanie:"<<finish-start; 
    }
};
int main(){
    mystring m("tick count for 2 percent daily growth over one week");
    KeepTime time(m);
    long double n=0.56;
    for(int i=0;i<7 ;i++){
        n+= n*1.002;
    }
    cout<< n<<endl;


}