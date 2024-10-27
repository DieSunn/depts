#ifndef TRIANGLE_H
#define TRIANGLE_H

class Triangle {
public:
    Triangle(double a, double b, double c);
    double perimeter() const;
    double area() const;

private:
    double a, b, c;
};

#endif // TRIANGLE_H
