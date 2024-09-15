#ifndef VIRTUAL_WALLET_H
#define VIRTUAL_WALLET_H

#include <exception>

// Класс исключения для обработки ошибок кошелька
class WalletException : public std::exception {
public:
    const char* what() const throw() {
        return "Недостаточно средств в кошельке!";
    }
};

// Класс "Виртуальный кошелек"
class VirtualWallet {
private:
    double balance; // Баланс кошелька
    double exchangeRateToEuro = 0.01; // Курс обмена валюты (допустим, это курс доллара к евро)
    double exchangeRateToDollar = 0.011; // Курс обмена валюты (допустим, это курс рубля к доллару)
public:
    // Конструктор
    VirtualWallet(double initial_balance);

    // Метод для добавления средств
    void deposit(double amount);

    // Метод для снятия средств
    void withdraw(double amount);

    // Метод для проверки баланса
    double getBalance();

    // Метод для конвертации баланса в евро
    double convertToEuro();

    // Метод для конвертации баланса в доллары
    double convertToDollar();
};

#endif // VIRTUAL_WALLET_H
