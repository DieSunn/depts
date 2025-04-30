#ifndef WALLET_H
#define WALLET_H

#include <QList>
#include "transaction.h"

class Wallet {
public:
    Wallet(double initialBalance = 0.0) : balance_(initialBalance) {}

    bool addMoney(double amount, const QString& desc = "", const QString& category = "");
    bool withdrawMoney(double amount, const QString& desc = "", const QString& category = "");
    double getBalance() const { return balance_; }
    QList<Transaction> getTransactions() const { return transactions_; }
    double getTotalIncome() const;
    double getTotalExpenses() const;

private:
    double balance_;
    QList<Transaction> transactions_;
};

#endif // WALLET_H
