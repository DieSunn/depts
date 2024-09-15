#include <iostream>
#include "VirtualWallet.h"

int main() {
    try {
        VirtualWallet myWallet(100.0); // Создаем кошелек с начальным балансом 100
        myWallet.deposit(50.0); // Добавляем 50
        std::cout << "Баланс: " << myWallet.getBalance() << " RUB" << std::endl; // Выводим баланс
        std::cout << "Баланс в евро: " << myWallet.convertToEuro() << " EUR" << std::endl; // Выводим баланс в евро
        std::cout << "Баланс в долларах: " << myWallet.convertToDollar() << " USD" << std::endl; // Выводим баланс в долларах
        myWallet.withdraw(200.0); // Пытаемся снять 200
    }
    catch (WalletException& e) {
        std::cerr << "Ошибка: " << e.what() << std::endl;
    }
    return 0;
}
