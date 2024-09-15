/// @author Rychkov R.V.
/// ���������� ������ "�����������"

#include "Triangle.h"
#include "cmath"

using namespace std;

// ����������� �� ���������
Triangle::Triangle()
{
    kat1 = 0.0;
    kat2 = 0.0;
    kat3 = 0.0;
}

// ����������� � �����������
Triangle::Triangle(float k1, float k2, float k3)
{
    setKatet(k1, k2, k3);
}

// �������
// todo: comment for check
void Triangle::setKatet(float k1, float k2, float k3)
{
    //�������� �� ������� ������, ���� ����, �� ������� ��������� �� ������ �� ������
    if (k1 <= 0 || k2 <= 0 || k3 <= 0 || k1 + k2 <= k3 || k1 + k3 <= k2 || k2 + k3 <= k1) {
        throw invalid_argument("Invalid triangle sides");
    }
    kat1 = k1;
    kat2 = k2;
    kat3 = k3;
}


// �������
int Triangle::getKatet1() const
{
    return kat1;
}

int Triangle::getKatet2() const
{
    return kat2;
}

int Triangle::getKatet3() const
{
    return kat3;
}

float Triangle::calculateArea() {
    // ���������� ������� ������
    float p = static_cast<float>(kat1 + kat2 + kat3) / 2.0;
    return sqrt(p * (p - kat1) * (p - kat2) * (p - kat3));
}

//��������� ������, ��������� �� 1-� �����
float Triangle::calculateHeight() {
    // ���������� ������� ������
    float p = (kat1 + kat2 + kat3) / 2;
    float area = sqrt(p * (p - kat1) * (p - kat2) * (p - kat3));
    return 2 * area / kat1;
}


