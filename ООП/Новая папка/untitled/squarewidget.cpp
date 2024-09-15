#include "SquareWidget.h"

SquareWidget::SquareWidget(QWidget *parent) : QWidget(parent), square(100) {
    QVBoxLayout *layout = new QVBoxLayout;
    input = new QLineEdit;
    QPushButton *button = new QPushButton("Update Square");
    layout->addWidget(input);
    layout->addWidget(button);
    setLayout(layout);

    connect(button, &QPushButton::clicked, this, &SquareWidget::updateSquare);
}

void SquareWidget::paintEvent(QPaintEvent *) {
    QPainter painter(this);
    painter.setBrush(Qt::blue);
    painter.drawRect(0, 0, square.getSide()-1, square.getSide()-1);
}

void SquareWidget::updateSquare() {
    bool ok;
    float newSide = input->text().toFloat(&ok);
    if (ok) {
        square.setSide(newSide);
        update();
    }
}
