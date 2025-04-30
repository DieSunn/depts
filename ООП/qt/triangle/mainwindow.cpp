#include "mainwindow.h"
#include "triangle.h"
#include <QWidget>
#include <QVBoxLayout>
#include <QFormLayout>
#include <QLineEdit>
#include <QPushButton>
#include <QIntValidator>
#include <QMessageBox>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
{
    // Задаем заголовок окна.
    setWindowTitle("Triangle Application");

    // Создаем центральный виджет и основной вертикальный layout.
    QWidget *centralWidget = new QWidget(this);
    setCentralWidget(centralWidget);
    QVBoxLayout *mainLayout = new QVBoxLayout(centralWidget);

    // Создаем виджет для отрисовки треугольника.
    triangleWidget = new Triangle();
    triangleWidget->setMinimumHeight(300);
    mainLayout->addWidget(triangleWidget);

    // Создаем панель управления для ввода координат.
    QWidget *controlPanel = new QWidget();
    QFormLayout *formLayout = new QFormLayout(controlPanel);

    // Инициализация полей ввода координат.
    lineEditX1 = new QLineEdit();
    lineEditY1 = new QLineEdit();
    lineEditX2 = new QLineEdit();
    lineEditY2 = new QLineEdit();
    lineEditX3 = new QLineEdit();
    lineEditY3 = new QLineEdit();

    // Ограничиваем ввод целочисленными значениями.
    lineEditX1->setValidator(new QIntValidator());
    lineEditY1->setValidator(new QIntValidator());
    lineEditX2->setValidator(new QIntValidator());
    lineEditY2->setValidator(new QIntValidator());
    lineEditX3->setValidator(new QIntValidator());
    lineEditY3->setValidator(new QIntValidator());

    // Добавляем поля в форму.
    formLayout->addRow("X1:", lineEditX1);
    formLayout->addRow("Y1:", lineEditY1);
    formLayout->addRow("X2:", lineEditX2);
    formLayout->addRow("Y2:", lineEditY2);
    formLayout->addRow("X3:", lineEditX3);
    formLayout->addRow("Y3:", lineEditY3);

    // Создаем кнопку для обновления треугольника.
    updateButton = new QPushButton("Обновить треугольник");
    formLayout->addRow(updateButton);

    // Добавляем панель управления в основной layout.
    mainLayout->addWidget(controlPanel);

    // Подключаем сигнал нажатия кнопки к слоту updateTriangle.
    connect(updateButton, &QPushButton::clicked, this, &MainWindow::updateTriangle);
}

void MainWindow::updateTriangle() {
    bool ok1, ok2, ok3, ok4, ok5, ok6;
    // Считываем значения из полей ввода.
    int x1 = lineEditX1->text().toInt(&ok1);
    int y1 = lineEditY1->text().toInt(&ok2);
    int x2 = lineEditX2->text().toInt(&ok3);
    int y2 = lineEditY2->text().toInt(&ok4);
    int x3 = lineEditX3->text().toInt(&ok5);
    int y3 = lineEditY3->text().toInt(&ok6);

    // Проверяем, что все данные корректно преобразованы в числа.
    if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6) {
        // Пытаемся установить новые вершины треугольника.
        if (!triangleWidget->setPoints(QPoint(x1, y1), QPoint(x2, y2), QPoint(x3, y3))) {
            QMessageBox::warning(this, "Ошибка ввода", "Введенные точки не образуют валидный треугольник.");
        }
    } else {
        QMessageBox::warning(this, "Ошибка ввода", "Пожалуйста, введите корректные целочисленные значения для всех координат.");
    }
}
