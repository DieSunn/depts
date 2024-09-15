/// @author Rychkov R.V.

#pragma once
#include <string>
#include <stdexcept>

using namespace std;

/// ����� �����������
class Triangle {
private:
    float kat1; /// ����� 1
    float kat2; /// ����� 2
    float kat3; /// ����� 3

public:
    /// ����������� (�������������� ����)
    Triangle();
    Triangle(float k1, float k2, float k3);

    /// ������
    void setKatet(float k1, float k2, float k3); /// ������ 1-� �����


    /// �������
    int getKatet1() const; /// �������� 1-� �����
    int getKatet2() const; /// �������� 2-� �����
    int getKatet3() const; /// �������� 3-� �����

    // ������ ��� ���������� ������� � ������
    float calculateArea();
    //��������� ������, ��������� �� 1-� �����
    float calculateHeight();

    /// ����� ������
    string to_string();
};

