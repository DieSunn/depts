#include <iostream>
#include <string>

struct Student
{
    std::string name;
    std::string group;
    std::string faculty;
    int year;
};

int main() {
    Student Student1;
    Student1.name = "Ivanov Ivan Ivanovich";
    Student1.group = "20.01.2";
    Student1.faculty = "HZ";
    Student1.year = 4;

    std::cout << Student1.name << " " << Student1.group << " " << Student1.faculty << " " << Student1.year << std::endl;
}