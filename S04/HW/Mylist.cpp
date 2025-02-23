#include<iostream>
using namespace std;
class list{
    public:
    int m_size ;
    int* m_nums;
    list(int size , int* nums):m_size(size){
        m_nums = new int[size];
        //m_nums = (int*)malloc(sizeof(int)*size)
        for(int i=0;i<m_size;i++){
            m_nums[i]=nums[i];
        }

    }
    void append(int appendednum){
        int* newarray = new int[m_size+1];
        for(int j=0;j<m_size;j++){
            newarray[j]=m_nums[j];
        }
        newarray[m_size]=appendednum;
        free(m_nums);
        m_nums=newarray;
        m_size+=1;
    }
    void append2(int appendednum){
        resize(m_size+1);
        m_nums[m_size-1]=appendednum;
    }
    void print(){
        cout<<"{";
        for(int i=0;i<m_size;i++){
            cout<<m_nums[i]<<", ";
        }
        cout<<"}\n";
    }
    void pop(int index){
        int* newarr =new int[m_size-1];
        for(int i=0,j=0;i<m_size;i++){
            if (i!=index){
                newarr[j]=m_nums[i];
                j++;
            }
        }
        free(m_nums);
        m_nums = newarr;
        m_size-=1;
        
    }
    void count() const{
        cout<<"tedad anasor:"<<m_size<< endl;
    }
    private:
        void resize(int newsize){
            int* m_numsnew  = (int*)malloc(sizeof(int)*newsize);
            for(int i=0;i<m_size;i++){
                m_numsnew[i]=m_nums[i];
            }
            free(m_nums);
            m_size = newsize;
            m_nums=m_numsnew;

        }

};

int main(){
    int n[5]={1,2,3,4,5};
    list m(5,n);
    m.count();
    m.print();
    m.append(14);
    m.print();
    m.append2(8);
    m.print();
    m.pop(1);
    m.print();
}