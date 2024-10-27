#include "Triangle.h"
#include <cmath>

Triangle::Triangle(double a, double b, double c) : a(a), b(b), c(c) {}

double Triangle::perimeter() const {
    return a + b + c;
}

double Triangle::area() const {
    double s = perimeter() / 2;
    return std::sqrt(s * (s - a) * (s - b) * (s - c));
}
