#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "wallet.h"

class QLineEdit;
class QPushButton;
class QComboBox;
class QTableWidget;
class QLabel;

class MainWindow : public QMainWindow {
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private slots:
    void onAddMoneyClicked();
    void onWithdrawMoneyClicked();
    void onShowStatsClicked();

private:
    Wallet wallet_;
    QLineEdit *amountInput_;
    QLineEdit *descriptionInput_;
    QComboBox *categoryCombo_;
    QPushButton *addButton_;
    QPushButton *withdrawButton_;
    QPushButton *statsButton_;
    QLabel *balanceLabel_;
    QTableWidget *historyTable_;

    void updateDisplay();
    void setupTable();
};

#endif // MAINWINDOW_H
