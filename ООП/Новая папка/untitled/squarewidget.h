#ifndef SQUAREWIDGET_H
#define SQUAREWIDGET_H

#include <QWidget>
#include <QPainter>
#include <QLineEdit>
#include <QPushButton>
#include <QVBoxLayout>
#include "Square.h"

class SquareWidget : public QWidget {
    Q_OBJECT
public:
    SquareWidget(QWidget *parent = 0);
protected:
    void paintEvent(QPaintEvent *);
private slots:
    void updateSquare();
private:
    Square square;
    QLineEdit *input;
};

#endif // SQUAREWIDGET_H
