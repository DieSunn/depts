#include <QApplication>
#include <QWidget>
#include <QLineEdit>
#include <QPushButton>
#include <QLabel>
#include <QVBoxLayout>
#include <QHBoxLayout>
#include <QMessageBox>
#include "Triangle.h"  // Подключаем заголовочный файл

class TriangleApp : public QWidget {
public:
    TriangleApp() {
        // Создаем элементы интерфейса
        QLabel *aLabel = new QLabel("Сторона a:");
        aInput = new QLineEdit;

        QLabel *bLabel = new QLabel("Сторона b:");
        bInput = new QLineEdit;

        QLabel *cLabel = new QLabel("Сторона c:");
        cInput = new QLineEdit;

        QPushButton *calcButton = new QPushButton("Рассчитать");
        connect(calcButton, &QPushButton::clicked, this, &TriangleApp::calculate);

        QLabel *perimeterLabel = new QLabel("Периметр:");
        perimeterOutput = new QLabel;

        QLabel *areaLabel = new QLabel("Площадь:");
        areaOutput = new QLabel;

        // Компонуем интерфейс
        QVBoxLayout *mainLayout = new QVBoxLayout;
        mainLayout->addWidget(aLabel);
        mainLayout->addWidget(aInput);
        mainLayout->addWidget(bLabel);
        mainLayout->addWidget(bInput);
        mainLayout->addWidget(cLabel);
        mainLayout->addWidget(cInput);
        mainLayout->addWidget(calcButton);
        mainLayout->addWidget(perimeterLabel);
        mainLayout->addWidget(perimeterOutput);
        mainLayout->addWidget(areaLabel);
        mainLayout->addWidget(areaOutput);

        setLayout(mainLayout);
    }

private slots:
    void calculate() {
        bool ok1, ok2, ok3;
        double a = aInput->text().toDouble(&ok1);
        double b = bInput->text().toDouble(&ok2);
        double c = cInput->text().toDouble(&ok3);

        if (ok1 && ok2 && ok3 && a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a) {
            Triangle triangle(a, b, c);
            perimeterOutput->setText(QString::number(triangle.perimeter()));
            areaOutput->setText(QString::number(triangle.area()));
        } else {
            QMessageBox::warning(this, "Ошибка", "Введите корректные значения сторон треугольника.");
        }
    }

private:
    QLineEdit *aInput;
    QLineEdit *bInput;
    QLineEdit *cInput;
    QLabel *perimeterOutput;
    QLabel *areaOutput;
};

int main(int argc, char *argv[]) {
    QApplication app(argc, argv);

    TriangleApp window;
    window.setWindowTitle("Triangle Calculator");
    window.show();

    return app.exec();
}
