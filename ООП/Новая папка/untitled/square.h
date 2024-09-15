#ifndef SQUARE_H
#define SQUARE_H

#include <string>

class Square {
private:
    float side; // Сторона квадрата

public:
    // Конструкторы (Инициализируют поля)
    Square();
    Square(float s);

    // Сеттер
    void setSide(float s); // Задать сторону

    // Геттер
    float getSide() const; // Получить сторону

    // Методы для вычисления площади и периметра
    float calculateArea();
    float calculatePerimeter();

    // Вывод данных
    std::string to_string();
};

#endif // SQUARE_H
