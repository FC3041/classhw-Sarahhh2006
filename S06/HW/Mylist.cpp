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
    void bubblesort(){
        for (int i=0;i<m_size-1;i++){
            for(int j=0; j<m_size-i-1;j++){
                if(m_nums[j]>m_nums[j+1]){
                    int t=m_nums[j];
                    m_nums[j]=m_nums[j+1];
                    m_nums[j+1]=t;
                }
            }
        }
    }
    void printlist(){
        for(int i=0;i<m_size;i++){
            cout<< m_nums[i]<<",";
        }
        cout<<endl;
    }
    



};

int main(){
    int n[5]={5,3,4,2,7};
    Mylist mylist1(5,15,n);
    mylist1.printlist();
    mylist1.bubblesort();
    mylist1.printlist();

    


    

}