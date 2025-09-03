#include<iostream>
using namespace std;
class Mystring{
    public:
    char* mystring ; 
    int capacity;
    
    int len(const char* ch){
        int count =0;
        while(*ch !='\0'){
            count++;
            ch++;
        }
        return count;}
    Mystring(const char* ch){
        capacity=len(ch);
        mystring = new char[capacity];
        for(int i=0;i<capacity;i++){
            // *mystring=*ch;
            // ch++;
            // mystring++;
            mystring[i]=ch[i];
        }
        mystring[capacity] = '\0';}

    void add(const Mystring& str){
        mystring=str.mystring;
        capacity = str.capacity;
    }
    bool checksubstr(const char* s) {
        int l1=len(mystring)-1;
        int l2= len(s)-1;
        int j;
        for(int i=0;i<=l1-l2; i++){
            for (int j=0;j <l2;j++){
                if(mystring[i+j]!=s[j]){
                    break;
                }
            }
            if(j==l2){
                return true;
            }
        }
        return false;
    }
    void printstr(){
        for(int i =0; i<len(mystring);i++){
        cout<< mystring[i];}
        cout<<endl;
    }


};

int main(){
    Mystring str1("sarah ahamdi");
    str1.printstr();
    str1.checksubstr("sar");
    str1.printstr();
    
    
    
}