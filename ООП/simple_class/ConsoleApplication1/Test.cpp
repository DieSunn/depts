#include "gtest/gtest.h"
#include "VirtualWallet.h"

// Тест на добавление средств в кошелек
TEST(VirtualWalletTest, Deposit) {
    VirtualWallet wallet(100.0);
    wallet.deposit(50.0);
    EXPECT_DOUBLE_EQ(wallet.getBalance(), 150.0);
}

// Тест на снятие средств из кошелька
TEST(VirtualWalletTest, Withdraw) {
    VirtualWallet wallet(100.0);
    wallet.withdraw(50.0);
    EXPECT_DOUBLE_EQ(wallet.getBalance(), 50.0);
}

// Тест на снятие средств больше, чем есть в кошельке
TEST(VirtualWalletTest, WithdrawMoreThanBalance) {
    VirtualWallet wallet(100.0);
    EXPECT_THROW(wallet.withdraw(200.0), WalletException);
}

// Тест на конвертацию в евро
TEST(VirtualWalletTest, ConvertToEuro) {
    VirtualWallet wallet(100.0);
    EXPECT_DOUBLE_EQ(wallet.convertToEuro(), 85.0);
}

// Тест на конвертацию в доллары
TEST(VirtualWalletTest, ConvertToDollar) {
    VirtualWallet wallet(100.0);
    EXPECT_DOUBLE_EQ(wallet.convertToDollar(), 1.1);
}
