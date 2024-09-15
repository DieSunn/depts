#include <QApplication>
#include "SquareWidget.h"

int main(int argc, char **argv) {
    QApplication app(argc, argv);

    SquareWidget squareWidget;
    squareWidget.show();

    return app.exec();
}
