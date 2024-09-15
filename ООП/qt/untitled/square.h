#pragma once
#include <string>
#include <stdexcept>

using namespace std;

/// Класс Квадрат
class Square {
private:
    float side; /// Сторона квадрата

public:
    /// Конструктор (Инициализирует поле)
    Square();
    Square(float s);

    /// Сеттер
    void setSide(float s); /// Задать сторону квадрата

    /// Геттеры
    int getSide() const; /// Получить сторону квадрата

    // Методы для вычисления площади и периметра
    float calculateArea();
    float calculatePerimeter();

    /// Вывод данных
    string to_string();
};
