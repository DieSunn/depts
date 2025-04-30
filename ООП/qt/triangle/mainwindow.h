#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

class Triangle;
class QLineEdit;
class QPushButton;

class MainWindow : public QMainWindow {
    Q_OBJECT
public:
    explicit MainWindow(QWidget *parent = nullptr);

private slots:
    // Слот для обработки нажатия кнопки обновления треугольника.
    void updateTriangle();

private:
    // Виджет для отрисовки треугольника.
    Triangle *triangleWidget;

    // Поля для ввода координат вершин.
    QLineEdit *lineEditX1;
    QLineEdit *lineEditY1;
    QLineEdit *lineEditX2;
    QLineEdit *lineEditY2;
    QLineEdit *lineEditX3;
    QLineEdit *lineEditY3;

    // Кнопка для обновления треугольника.
    QPushButton *updateButton;
};

#endif // MAINWINDOW_H
