using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualWalletApp.Models
{
    /// <summary>
    /// Представляет виртуальный кошелек, управляющий транзакциями и балансом.
    /// </summary>
    public class Wallet
    {
        // Приватное поле для хранения списка транзакций
        private readonly List<Transaction> _transactions;

        /// <summary>
        /// Предоставляет доступ только для чтения к списку транзакций.
        /// Использование IReadOnlyList защищает список от изменений извне.
        /// </summary>
        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

        /// <summary>
        /// Текущий баланс кошелька. Рассчитывается на основе транзакций.
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// Событие, возникающее при изменении баланса или списка транзакций.
        /// Полезно для обновления UI.
        /// </summary>
        public event EventHandler WalletChanged; 

        /// <summary>
        /// Инициализирует новый экземпляр кошелька с пустым списком транзакций и нулевым балансом.
        /// </summary>
        public Wallet()
        {
            _transactions = new List<Transaction>();
            Balance = 0m; // m - суффикс для decimal
        }

        /// <summary>
        /// Добавляет транзакцию дохода.
        /// </summary>
        /// <param name="amount">Сумма дохода (должна быть положительной).</param>
        /// <param name="description">Описание дохода.</param>
        public void AddIncome(decimal amount, string description)
        {
            // Проверка на валидность суммы уже есть в конструкторе Transaction
            var incomeTransaction = new Transaction(DateTime.Now, TransactionType.Income, amount, description);
            AddTransaction(incomeTransaction);
        }

        /// <summary>
        /// Добавляет транзакцию расхода.
        /// </summary>
        /// <param name="amount">Сумма расхода (должна быть положительной).</param>
        /// <param name="description">Описание расхода.</param>
        /// <exception cref="InvalidOperationException">Выбрасывается, если на балансе недостаточно средств.</exception>
        public void AddExpense(decimal amount, string description)
        {
            // Проверка на валидность суммы уже есть в конструкторе Transaction
            if (amount > Balance)
            {
                // Нельзя потратить больше, чем есть на балансе
                throw new InvalidOperationException($"Недостаточно средств на балансе. Текущий баланс: {Balance:C}, попытка списать: {amount:C}.");
            }
            var expenseTransaction = new Transaction(DateTime.Now, TransactionType.Expense, amount, description);
            AddTransaction(expenseTransaction);
        }

        /// <summary>
        /// Приватный метод для добавления транзакции в список и пересчета баланса.
        /// </summary>
        /// <param name="transaction">Добавляемая транзакция.</param>
        private void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            // Сортируем транзакции по дате (от новых к старым) для наглядности
            _transactions.Sort((t1, t2) => t2.Date.CompareTo(t1.Date));
            RecalculateBalance(); // Пересчитываем баланс после добавления
            // Уведомляем подписчиков (например, контроллер) об изменениях
            OnWalletChanged();
        }

        /// <summary>
        /// Пересчитывает текущий баланс на основе всех транзакций.
        /// </summary>
        private void RecalculateBalance()
        {
            decimal newBalance = 0m;
            foreach (var transaction in _transactions)
            {
                if (transaction.Type == TransactionType.Income)
                {
                    newBalance += transaction.Amount;
                }
                else // TransactionType.Expense
                {
                    newBalance -= transaction.Amount;
                }
            }
            Balance = newBalance;
        }

        /// <summary>
        /// Вызывает событие WalletChanged.
        /// </summary>
        protected virtual void OnWalletChanged()
        {
            WalletChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}