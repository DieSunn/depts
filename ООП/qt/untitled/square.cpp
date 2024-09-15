#include "Square.h"
#include <cmath>

// Конструкторы
Square::Square() : side(0.0f) {}
Square::Square(float s) : side(s) {}

// Сеттер
void Square::setSide(float s) {
    if (s <= 0) {
        throw invalid_argument("Сторона квадрата должна быть положительной.");
    }
    side = s;
}

// Геттеры
int Square::getSide() const {
    return side;
}

// Методы для вычисления площади и периметра
float Square::calculateArea() {
    return pow(side, 2);
}

float Square::calculatePerimeter() {
    return 4 * side;
}

// Вывод данных
string Square::to_string() {
    return "Квадрат со стороной " + std::to_string(side);
}
