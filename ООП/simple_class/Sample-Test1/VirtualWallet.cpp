#include "VirtualWallet.h"

// Конструктор
VirtualWallet::VirtualWallet(double initial_balance) : balance(initial_balance) {}

// Метод для добавления средств
void VirtualWallet::deposit(double amount) {
    balance += amount;
}

// Метод для снятия средств
void VirtualWallet::withdraw(double amount) {
    if (balance < amount) {
        throw WalletException();
    }
    balance -= amount;
}

// Метод для проверки баланса
double VirtualWallet::getBalance() {
    return balance;
}

// Метод для конвертации баланса в евро
double VirtualWallet::convertToEuro() {
    return balance * exchangeRateToEuro;
}

// Метод для конвертации баланса в доллары
double VirtualWallet::convertToDollar() {
    return balance * exchangeRateToDollar;
}
