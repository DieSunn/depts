#include <QApplication>
#include <QMainWindow>
#include <QWidget>
#include <QVBoxLayout>
#include <QFormLayout>
#include <QLineEdit>
#include <QPushButton>
#include <QMessageBox>
#include <QIntValidator>
#include "triangle.h"

int main(int argc, char *argv[]) {
    QApplication app(argc, argv);

    // Создаем главное окно.
    QMainWindow mainWindow;
    mainWindow.setWindowTitle("Triangle Application");

    // Центральный виджет с вертикальным лейаутом.
    QWidget *centralWidget = new QWidget(&mainWindow);
    mainWindow.setCentralWidget(centralWidget);
    QVBoxLayout *mainLayout = new QVBoxLayout(centralWidget);

    // Создаем виджет для отрисовки треугольника.
    Triangle *triangleWidget = new Triangle();
    triangleWidget->setMinimumHeight(300);
    mainLayout->addWidget(triangleWidget);

    // Панель управления для ввода координат.
    QWidget *controlPanel = new QWidget();
    QFormLayout *formLayout = new QFormLayout(controlPanel);

    QLineEdit *lineEditX1 = new QLineEdit();
    QLineEdit *lineEditY1 = new QLineEdit();
    QLineEdit *lineEditX2 = new QLineEdit();
    QLineEdit *lineEditY2 = new QLineEdit();
    QLineEdit *lineEditX3 = new QLineEdit();
    QLineEdit *lineEditY3 = new QLineEdit();

    // Устанавливаем валидаторы для ввода целых чисел.
    lineEditX1->setValidator(new QIntValidator());
    lineEditY1->setValidator(new QIntValidator());
    lineEditX2->setValidator(new QIntValidator());
    lineEditY2->setValidator(new QIntValidator());
    lineEditX3->setValidator(new QIntValidator());
    lineEditY3->setValidator(new QIntValidator());

    formLayout->addRow("X1:", lineEditX1);
    formLayout->addRow("Y1:", lineEditY1);
    formLayout->addRow("X2:", lineEditX2);
    formLayout->addRow("Y2:", lineEditY2);
    formLayout->addRow("X3:", lineEditX3);
    formLayout->addRow("Y3:", lineEditY3);

    QPushButton *updateButton = new QPushButton("Обновить треугольник");
    formLayout->addRow(updateButton);
    mainLayout->addWidget(controlPanel);

    // По нажатию кнопки читаем данные, устанавливаем вершины и проверяем корректность.
    QObject::connect(updateButton, &QPushButton::clicked, [=]() {
        bool ok1, ok2, ok3, ok4, ok5, ok6;
        int x1 = lineEditX1->text().toInt(&ok1);
        int y1 = lineEditY1->text().toInt(&ok2);
        int x2 = lineEditX2->text().toInt(&ok3);
        int y2 = lineEditY2->text().toInt(&ok4);
        int x3 = lineEditX3->text().toInt(&ok5);
        int y3 = lineEditY3->text().toInt(&ok6);

        if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6) {
            bool result = triangleWidget->setPoints(QPoint(x1, y1), QPoint(x2, y2), QPoint(x3, y3));
            if (!result) {
                QMessageBox::warning(controlPanel, "Неверный ввод", "Введенные точки не образуют валидный треугольник.");
            }
        } else {
            QMessageBox::warning(controlPanel, "Ошибка ввода", "Пожалуйста, введите корректные целочисленные значения для всех координат.");
        }
    });

    mainWindow.resize(400, 500);
    mainWindow.show();

    return app.exec();
}
