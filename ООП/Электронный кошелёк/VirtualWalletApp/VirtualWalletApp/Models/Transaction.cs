using System;

namespace VirtualWalletApp.Models
{
    /// <summary>
    /// Представляет одну финансовую транзакцию.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Дата и время проведения транзакции.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Тип транзакции (Доход или Расход).
        /// </summary>
        public TransactionType Type { get; }

        /// <summary>
        /// Сумма транзакции (всегда положительная).
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Описание транзакции.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Создает новый экземпляр транзакции.
        /// </summary>
        /// <param name="date">Дата транзакции.</param>
        /// <param name="type">Тип транзакции.</param>
        /// <param name="amount">Сумма (должна быть положительной).</param>
        /// <param name="description">Описание.</param>
        /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если сумма отрицательная.</exception>
        public Transaction(DateTime date, TransactionType type, decimal amount, string description)
        {
            if (amount < 0)
            {
                // Сумма транзакции не может быть отрицательной
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма транзакции не может быть отрицательной.");
            }

            Date = date;
            Type = type;
            Amount = amount;
            Description = description ?? string.Empty; // Описание может быть пустым, но не null
        }

        // Переопределение ToString для удобного отображения в списке
        public override string ToString()
        {
            string sign = Type == TransactionType.Income ? "+" : "-";
            return $"{Date:dd.MM.yyyy HH:mm} | {Type} | {sign}{Amount:C} | {Description}"; // C - формат валюты
        }
    }
}