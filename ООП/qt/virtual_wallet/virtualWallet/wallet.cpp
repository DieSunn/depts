#include "wallet.h"

bool Wallet::addMoney(double amount, const QString& desc, const QString& category) {
    if (amount <= 0) return false;
    balance_ += amount;
    transactions_.append(Transaction(amount, Transaction::Income, desc, category));
    return true;
}

bool Wallet::withdrawMoney(double amount, const QString& desc, const QString& category) {
    if (amount <= 0 || amount > balance_) return false;
    balance_ -= amount;
    transactions_.append(Transaction(amount, Transaction::Expense, desc, category));
    return true;
}

double Wallet::getTotalIncome() const {
    double total = 0;
    for (const Transaction& t : transactions_) {
        if (t.type() == Transaction::Income) total += t.amount();
    }
    return total;
}

double Wallet::getTotalExpenses() const {
    double total = 0;
    for (const Transaction& t : transactions_) {
        if (t.type() == Transaction::Expense) total += t.amount();
    }
    return total;
}
