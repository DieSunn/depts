#ifndef TRANSACTION_H
#define TRANSACTION_H

#include <QString>
#include <QDateTime>

class Transaction {
public:
    enum Type { Income, Expense };

    Transaction(double amount, Type type, const QString& description = "", const QString& category = "")
        : amount_(amount), type_(type), description_(description), category_(category) {
        dateTime_ = QDateTime::currentDateTime();
    }

    double amount() const { return amount_; }
    Type type() const { return type_; }
    QString description() const { return description_; }
    QString category() const { return category_; }
    QDateTime dateTime() const { return dateTime_; }

private:
    double amount_;
    Type type_;
    QString description_;
    QString category_;
    QDateTime dateTime_;
};

#endif // TRANSACTION_H
