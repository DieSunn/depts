/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 6.7.0
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QLabel>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPlainTextEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralwidget;
    QTextEdit *textEdit_4;
    QLabel *Kat2Label;
    QLabel *Kat1Label;
    QTextEdit *textEdit_2;
    QTextEdit *textEdit;
    QPushButton *pushButton;
    QLabel *Kat3Label;
    QPlainTextEdit *plainTextEdit;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName("MainWindow");
        MainWindow->resize(470, 357);
        centralwidget = new QWidget(MainWindow);
        centralwidget->setObjectName("centralwidget");
        textEdit_4 = new QTextEdit(centralwidget);
        textEdit_4->setObjectName("textEdit_4");
        textEdit_4->setGeometry(QRect(20, 210, 111, 31));
        Kat2Label = new QLabel(centralwidget);
        Kat2Label->setObjectName("Kat2Label");
        Kat2Label->setGeometry(QRect(20, 100, 63, 20));
        Kat1Label = new QLabel(centralwidget);
        Kat1Label->setObjectName("Kat1Label");
        Kat1Label->setGeometry(QRect(20, 10, 63, 20));
        textEdit_2 = new QTextEdit(centralwidget);
        textEdit_2->setObjectName("textEdit_2");
        textEdit_2->setGeometry(QRect(20, 120, 111, 31));
        textEdit = new QTextEdit(centralwidget);
        textEdit->setObjectName("textEdit");
        textEdit->setGeometry(QRect(20, 30, 111, 31));
        pushButton = new QPushButton(centralwidget);
        pushButton->setObjectName("pushButton");
        pushButton->setGeometry(QRect(30, 260, 83, 29));
        Kat3Label = new QLabel(centralwidget);
        Kat3Label->setObjectName("Kat3Label");
        Kat3Label->setGeometry(QRect(20, 190, 63, 20));
        plainTextEdit = new QPlainTextEdit(centralwidget);
        plainTextEdit->setObjectName("plainTextEdit");
        plainTextEdit->setGeometry(QRect(180, 30, 261, 211));
        MainWindow->setCentralWidget(centralwidget);
        menubar = new QMenuBar(MainWindow);
        menubar->setObjectName("menubar");
        menubar->setGeometry(QRect(0, 0, 470, 25));
        MainWindow->setMenuBar(menubar);
        statusbar = new QStatusBar(MainWindow);
        statusbar->setObjectName("statusbar");
        MainWindow->setStatusBar(statusbar);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QCoreApplication::translate("MainWindow", "Triangle", nullptr));
        Kat2Label->setText(QCoreApplication::translate("MainWindow", "\320\232\320\260\321\202\320\265\321\202 2:", nullptr));
        Kat1Label->setText(QCoreApplication::translate("MainWindow", "\320\232\320\260\321\202\320\265\321\202 1:", nullptr));
        pushButton->setText(QCoreApplication::translate("MainWindow", "\320\222\321\213\321\207\320\270\321\201\320\273\320\270\321\202\321\214", nullptr));
        Kat3Label->setText(QCoreApplication::translate("MainWindow", "\320\232\320\260\321\202\320\265\321\202 3:", nullptr));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
