#include<iostream>
using namespace std;
class Mystring{
    public:
    char* mystring ; 
    int capacity;
    
    int size(const char* ch){
        int count =1;
        while(*ch !='\0'){
            count++;
            ch++;
        }
        return count;}
    Mystring(const char* ch){
        capacity=size(ch);
        mystring = new char[capacity];
        for(int i=0;i<capacity;i++){
            // *mystring=*ch;
            // ch++;
            // mystring++;
            mystring[i]=ch[i];
        }
        mystring[capacity] = '\0';}
    // string(){
    //     mystring =new char[1];
    //     mystring[0]='\0';
    // }
    Mystring(){
        mystring = nullptr;
        capacity = 0;

    }
    void assign(const char* str){
        free(mystring);
        int len = size(str);
        mystring = new char[len];
        for(int i=0;i<len;i++){
            mystring[i]= str[i];
        }
        mystring[len]='\0';
    }
    void append(const char* n){
        int len =size(mystring);
        int len1= size(n);
        char* newstring= new char[len+len1+1];
        for(int i=0;i<len-1;i++){
            newstring[i]=mystring[i];
        }
        for(int i=0;i<len1;i++){
            newstring[len-1+i]=n[i];
        }
        newstring[len1+len-1]='\0';
        free(mystring);
        mystring=newstring;
        
    }
    void printstr(){
        for(int i =0; i<size(mystring);i++){
        cout<< mystring[i];}
        cout<<endl;
    }


};

int main(){
    // char* strr ="sarah";
    Mystring str1("sarah");
    str1.printstr();
    cout<< str1.size("saba")<<endl;
    str1.assign("niloo\t");
    str1.printstr();
    str1.append("doste mane");
    str1.printstr();

    // Mystring str2();
    // str2.printstr();
}