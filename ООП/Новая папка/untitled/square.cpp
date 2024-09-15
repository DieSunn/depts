#include "Square.h"
#include <sstream> // Для to_string

Square::Square() : side(0) {}

Square::Square(float s) : side(s) {}

void Square::setSide(float s) {
    side = s;
}

float Square::getSide() const { return side; }

float Square::calculateArea() {
    // Площадь квадрата равна стороне в квадрате
    return side * side;
}

float Square::calculatePerimeter() {
    // Периметр квадрата равен учетверенной стороне
    return 4 * side;
}

std::string Square::to_string() {
    std::ostringstream ss;
    ss << "Square: side = " << side;
    return ss.str();
}
