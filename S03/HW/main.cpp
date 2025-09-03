#include<iostream>
using namespace std;
class Student
{
public:
    int m_stdNum;
    char m_FirstName[20];
    char m_LastName[20];
    int m_CoursesPassed;
    int m_Credits[40];
    double m_Grades[40];
    char* m_CourseNames[40];

    Student(int stdnum,const char* fname, const char* lname)
    {
        m_stdNum = stdnum;
        strcopy(m_FirstName , fname);
        strcopy(m_LastName , lname);
        cout<< "basic information of student:\n student number:"<< m_stdNum<<" first name: "<< m_FirstName <<" last name: "<< m_LastName;
    }
    ~Student()
    {
        for (int i=0; i<m_CoursesPassed; i++) {
            delete[] m_CourseNames[i];
        }
    }
    double GetGPA()
    {
        double sumGrade = 0;
        int sumCredit = 0;
        for(int i=0; i<m_CoursesPassed; i++) {
            sumGrade += m_Credits[i] * m_Grades[i];
            sumCredit += m_Credits[i];
        }
        return sumGrade / sumCredit;
    }

    void list_courses()
    {
        for(int i=0; i<m_CoursesPassed; i++) {
            cout << m_CourseNames[i] << ": "
                      << m_Credits[i] << " : "
                      << m_Grades[i] << std::endl;        
        }
    }

    int lenstr(char* x){
        int count =1;
        while(*x !='\0'){
            x++;
            count++;

        }
        return count ;
    }
    char* strcopy(char* des, const char* origin){
        int i =0;
        while(origin[i]!='\0'){
            des[i]=origin[i];
            i++;
        }
        return des;
    }
    void register_course(int credits, char* name, double grade)
    {
        m_Credits[m_CoursesPassed] = credits;
        m_Grades[m_CoursesPassed] = grade;
        char* namecopy = new char[lenstr(name)];
            //(char*) malloc(strlen(name) + 1);
        strcopy(namecopy, name);
        m_CourseNames[m_CoursesPassed] = namecopy;
        m_CoursesPassed++;
    }
    Student(){}
};

int main()
{
    Student s(4034, "tina", "farahani");
    // Student* s2 = new Student(3423, "asdf", "lasdkfj");
    // Student* s3 = &s;
    // int * pn = new int[10];
    s.m_CoursesPassed = 0;
    char bufc[100];
    double grade;
    int credits;
    while(true)
    {
        cout << "\ncourse name?" ;
        cin >> bufc ;
        if (*bufc == 'A')
            break;
        cout << "course credits?" ;
        cin >> credits ;
        cout << "course grade?" ;
        cin >> grade ;
        s.register_course(credits, bufc, grade);
    }
    s.list_courses();
    cout << s.GetGPA() <<endl;
    return 0;
}