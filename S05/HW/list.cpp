#include<iostream>
using namespace std;
class Mylist{
    public:
    int m_size;
    int m_capacity;
    int* m_nums;
    Mylist(){
        m_size=0;
        m_capacity=0;
        m_nums=nullptr;
    }
    Mylist(int size ,int capacity, int* nums){
        m_size=size;
        capacity = m_capacity;
        m_nums= new int[capacity];
        for(int i=0;i<size;i++){
            m_nums[i]= nums[i];
        }
    }

    void pushback(int value){
        if (m_size==m_capacity){
            if (m_size==0){
                resize(1);
            }
            else{
                resize(m_capacity+1);
            }
        }
        m_nums[m_size]=value;
        m_size++;
    }

    void insert(int index , int value){
        if (m_size==m_capacity){
            if (m_size==0){
                resize(1);
            }
            else{
                resize(m_capacity+1);
            }}
            for(int i=m_size ; i>index;i--){
                m_nums[i] = m_nums[i-1];
            }
            m_nums[index]= value;
            m_size++;
        }

    void erase(int index){
            for(int i =index ; i<m_size-1;i++){
                m_nums[i]=m_nums[i+1];
            }
            m_size--;
        }
    void resize(int newsize){
        int* newnums = new int[newsize];
        for(int i=0;i<m_size;i++){
            newnums[i] = m_nums[i];
        }
        free(m_nums);
        newnums = m_nums;
        m_size = newsize;}
    void printlist(){
        for(int i=0;i<m_size;i++){
            cout<< m_nums[i]<<",";
        }
        cout<<endl;
    }
    



};

int main(){
    int n[5]={1,2,3,4,5};
    Mylist mylist1(5,15,n);
    mylist1.printlist();
    mylist1.pushback(6);
    mylist1.printlist();
    mylist1.insert(2,0);
    mylist1.printlist();
    mylist1.erase(2);
    mylist1.printlist();


    

}