#include "mainwindow.h"
#include <QGridLayout>
#include <QLabel>
#include <QLineEdit>
#include <QPushButton>
#include <QComboBox>
#include <QTableWidget>
#include <QMessageBox>
#include <QHeaderView>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent), wallet_(100.0) {
    QWidget *centralWidget = new QWidget(this);
    setCentralWidget(centralWidget);

    QGridLayout *layout = new QGridLayout(centralWidget);

    // Элементы интерфейса
    amountInput_ = new QLineEdit(this);
    descriptionInput_ = new QLineEdit(this);
    categoryCombo_ = new QComboBox(this);
    addButton_ = new QPushButton("Добавить", this);
    withdrawButton_ = new QPushButton("Снять", this);
    statsButton_ = new QPushButton("Статистика", this);
    balanceLabel_ = new QLabel(this);
    historyTable_ = new QTableWidget(this);

    // Настройка категорий
    categoryCombo_->addItems({"Без категории", "Еда", "Транспорт", "Развлечения", "Покупки"});

    // Стилизация
    balanceLabel_->setStyleSheet("font-size: 18px; font-weight: bold; color: #2E7D32;");
    addButton_->setStyleSheet("background-color: #4CAF50; color: white;");
    withdrawButton_->setStyleSheet("background-color: #F44336; color: white;");
    statsButton_->setStyleSheet("background-color: #2196F3; color: white;");

    // Настройка таблицы
    setupTable();

    // Расположение элементов
    layout->addWidget(new QLabel("Сумма:"), 0, 0);
    layout->addWidget(amountInput_, 0, 1);
    layout->addWidget(new QLabel("Описание:"), 1, 0);
    layout->addWidget(descriptionInput_, 1, 1);
    layout->addWidget(new QLabel("Категория:"), 2, 0);
    layout->addWidget(categoryCombo_, 2, 1);
    layout->addWidget(addButton_, 3, 0);
    layout->addWidget(withdrawButton_, 3, 1);
    layout->addWidget(statsButton_, 4, 0, 1, 2);
    layout->addWidget(new QLabel("Баланс:"), 5, 0);
    layout->addWidget(balanceLabel_, 5, 1);
    layout->addWidget(new QLabel("История:"), 6, 0);
    layout->addWidget(historyTable_, 6, 1);

    // Подключение сигналов
    connect(addButton_, &QPushButton::clicked, this, &MainWindow::onAddMoneyClicked);
    connect(withdrawButton_, &QPushButton::clicked, this, &MainWindow::onWithdrawMoneyClicked);
    connect(statsButton_, &QPushButton::clicked, this, &MainWindow::onShowStatsClicked);

    updateDisplay();
}

MainWindow::~MainWindow() {}

void MainWindow::setupTable() {
    historyTable_->setColumnCount(4);
    historyTable_->setHorizontalHeaderLabels({"Дата", "Тип", "Сумма", "Описание", "Категория"});
    historyTable_->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
}

void MainWindow::onAddMoneyClicked() {
    bool ok;
    double amount = amountInput_->text().toDouble(&ok);
    if (!ok || amount <= 0) {
        QMessageBox::warning(this, "Ошибка", "Введите корректную сумму!");
        return;
    }
    QString desc = descriptionInput_->text();
    QString category = categoryCombo_->currentText();
    if (wallet_.addMoney(amount, desc, category)) {
        updateDisplay();
    }
    amountInput_->clear();
    descriptionInput_->clear();
}

void MainWindow::onWithdrawMoneyClicked() {
    bool ok;
    double amount = amountInput_->text().toDouble(&ok);
    if (!ok || amount <= 0) {
        QMessageBox::warning(this, "Ошибка", "Введите корректную сумму!");
        return;
    }
    if (amount > wallet_.getBalance()) {
        QMessageBox::warning(this, "Ошибка", "Недостаточно средств!");
        return;
    }
    QString desc = descriptionInput_->text();
    QString category = categoryCombo_->currentText();
    if (wallet_.withdrawMoney(amount, desc, category)) {
        updateDisplay();
    }
    amountInput_->clear();
    descriptionInput_->clear();
}

void MainWindow::onShowStatsClicked() {
    double income = wallet_.getTotalIncome();
    double expenses = wallet_.getTotalExpenses();
    double net = income - expenses;
    QString stats = QString("Доходы: %1\nРасходы: %2\nЧистый результат: %3")
                        .arg(income).arg(expenses).arg(net);
    QMessageBox::information(this, "Статистика", stats);
}

void MainWindow::updateDisplay() {
    balanceLabel_->setText(QString("Баланс: %1").arg(wallet_.getBalance()));

    historyTable_->setRowCount(0);
    for (const Transaction& t : wallet_.getTransactions()) {
        int row = historyTable_->rowCount();
        historyTable_->insertRow(row);
        historyTable_->setItem(row, 0, new QTableWidgetItem(t.dateTime().toString()));
        historyTable_->setItem(row, 1, new QTableWidgetItem(t.type() == Transaction::Income ? "Доход" : "Расход"));
        historyTable_->setItem(row, 2, new QTableWidgetItem(QString::number(t.amount())));
        historyTable_->setItem(row, 3, new QTableWidgetItem(t.description()));
        historyTable_->setItem(row, 4, new QTableWidgetItem(t.category()));
    }
}
,
