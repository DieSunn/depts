using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualWalletApp.Models;
using System; // Для InvalidOperationException

namespace VirtualWalletApp.Tests
{
    /// <summary>
    /// Модульные тесты для класса Wallet.
    /// </summary>
    [TestClass]
    public class WalletTests
    {
        /// <summary>
        /// Тест: Начальный баланс нового кошелька должен быть равен нулю.
        /// </summary>
        [TestMethod]
        public void NewWallet_ShouldHaveZeroBalance()
        {
            // Arrange (Подготовка)
            var wallet = new Wallet();

            // Act (Действие)
            var balance = wallet.Balance;

            // Assert (Проверка)
            Assert.AreEqual(0m, balance, "Начальный баланс должен быть 0.");
        }

        /// <summary>
        /// Тест: Добавление дохода должно корректно увеличивать баланс.
        /// </summary>
        [TestMethod]
        public void AddIncome_ShouldIncreaseBalanceCorrectly()
        {
            // Arrange
            var wallet = new Wallet();
            decimal incomeAmount = 100.50m;
            string description = "Зарплата";

            // Act
            wallet.AddIncome(incomeAmount, description);

            // Assert
            Assert.AreEqual(incomeAmount, wallet.Balance, "Баланс должен увеличиться на сумму дохода.");
            Assert.AreEqual(1, wallet.Transactions.Count, "Должна быть добавлена одна транзакция.");
            Assert.AreEqual(TransactionType.Income, wallet.Transactions[0].Type, "Тип транзакции должен быть Income.");
            Assert.AreEqual(incomeAmount, wallet.Transactions[0].Amount, "Сумма транзакции должна совпадать.");
        }

        /// <summary>
        /// Тест: Добавление расхода должно корректно уменьшать баланс.
        /// </summary>
        [TestMethod]
        public void AddExpense_ShouldDecreaseBalanceCorrectly()
        {
            // Arrange
            var wallet = new Wallet();
            wallet.AddIncome(200m, "Начальный капитал"); // Добавляем средства для списания
            decimal expenseAmount = 50.25m;
            string description = "Покупка продуктов";

            // Act
            wallet.AddExpense(expenseAmount, description);

            // Assert
            Assert.AreEqual(200m - expenseAmount, wallet.Balance, "Баланс должен уменьшиться на сумму расхода.");
            Assert.AreEqual(2, wallet.Transactions.Count, "Должно быть две транзакции (доход и расход).");
            // Транзакции сортируются по дате, последняя добавленная будет первой
            Assert.AreEqual(TransactionType.Expense, wallet.Transactions[0].Type, "Тип последней транзакции должен быть Expense.");
            Assert.AreEqual(expenseAmount, wallet.Transactions[0].Amount, "Сумма последней транзакции должна совпадать.");
        }

        /// <summary>
        /// Тест: Попытка добавить расход, превышающий баланс, должна вызывать исключение.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Должно быть вызвано исключение при попытке потратить больше, чем есть.")]
        public void AddExpense_WhenInsufficientFunds_ShouldThrowException()
        {
            // Arrange
            var wallet = new Wallet();
            wallet.AddIncome(50m, "Мало денег");
            decimal expenseAmount = 100m; // Больше, чем на балансе
            string description = "Крупная покупка";

            // Act
            wallet.AddExpense(expenseAmount, description); // Здесь ожидается исключение

            // Assert - Не требуется, т.к. используется [ExpectedException]
        }

        /// <summary>
        /// Тест: Попытка добавить доход с отрицательной суммой должна вызывать исключение.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Должно быть вызвано исключение при отрицательной сумме.")]
        public void AddIncome_WithNegativeAmount_ShouldThrowException()
        {
            // Arrange
            var wallet = new Wallet();
            decimal negativeAmount = -100m;
            string description = "Ошибка";

            // Act
            wallet.AddIncome(negativeAmount, description); // Ожидается исключение из конструктора Transaction

            // Assert - Не требуется
        }

        /// <summary>
        /// Тест: Попытка добавить расход с отрицательной суммой должна вызывать исключение.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Должно быть вызвано исключение при отрицательной сумме.")]
        public void AddExpense_WithNegativeAmount_ShouldThrowException()
        {
            // Arrange
            var wallet = new Wallet();
            wallet.AddIncome(200m, "Начальный капитал");
            decimal negativeAmount = -50m;
            string description = "Ошибка";

            // Act
            wallet.AddExpense(negativeAmount, description); // Ожидается исключение из конструктора Transaction

            // Assert - Не требуется
        }

        /// <summary>
        /// Тест: Событие WalletChanged должно срабатывать при добавлении транзакции.
        /// </summary>
        [TestMethod]
        public void AddTransaction_ShouldRaiseWalletChangedEvent()
        {
            // Arrange
            var wallet = new Wallet();
            bool eventRaised = false;
            // Подписываемся на событие
            wallet.WalletChanged += (sender, args) => { eventRaised = true; };

            // Act
            wallet.AddIncome(10m, "Тест события");

            // Assert
            Assert.IsTrue(eventRaised, "Событие WalletChanged должно было сработать.");
        }
    }
}