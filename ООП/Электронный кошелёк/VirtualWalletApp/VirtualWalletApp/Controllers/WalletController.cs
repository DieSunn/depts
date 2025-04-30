using System;
using System.Globalization; // Для парсинга decimal
using VirtualWalletApp.Models;

namespace VirtualWalletApp.Controllers
{
    /// <summary>
    /// Контроллер для управления взаимодействием между моделью Wallet и представлением MainWindow.
    /// </summary>
    public class WalletController
    {
        private readonly Wallet _wallet; // Ссылка на модель
        private readonly MainWindow _view; // Ссылка на представление

        /// <summary>
        /// Инициализирует контроллер, связывая его с моделью и представлением.
        /// </summary>
        /// <param name="wallet">Экземпляр кошелька (модель).</param>
        /// <param name="view">Экземпляр главного окна (представление).</param>
        public WalletController(Wallet wallet, MainWindow view)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        /// <summary>
        /// Пытается добавить доход на основе ввода пользователя.
        /// </summary>
        /// <param name="amountStr">Сумма дохода в виде строки.</param>
        /// <param name="description">Описание дохода.</param>
        public void AddIncome(string amountStr, string description)
        {
            // Валидация и парсинг ввода
            if (TryParseAmount(amountStr, out decimal amount))
            {
                try
                {
                    _wallet.AddIncome(amount, description);
                    // Модель сама вызовет событие WalletChanged,
                    // которое обработает View и вызовет UpdateView().
                    // Можно было бы вызвать UpdateView() и отсюда, но через событие - правильнее.
                    _view.ShowStatusMessage($"Доход '{description}' на сумму {amount:C} успешно добавлен.");
                }
                catch (ArgumentOutOfRangeException ex) // Ошибка из конструктора Transaction (хотя тут не должна быть)
                {
                    _view.ShowStatusMessage($"Ошибка: {ex.Message}");
                }
                catch (Exception ex) // Другие возможные ошибки
                {
                    _view.ShowStatusMessage($"Произошла ошибка при добавлении дохода: {ex.Message}");
                }
            }
            else
            {
                _view.ShowStatusMessage("Ошибка: Некорректная сумма. Введите положительное число.");
            }
        }

        /// <summary>
        /// Пытается добавить расход на основе ввода пользователя.
        /// </summary>
        /// <param name="amountStr">Сумма расхода в виде строки.</param>
        /// <param name="description">Описание расхода.</param>
        public void AddExpense(string amountStr, string description)
        {
            // Валидация и парсинг ввода
            if (TryParseAmount(amountStr, out decimal amount))
            {
                try
                {
                    _wallet.AddExpense(amount, description);
                    // Модель сама вызовет событие WalletChanged -> UpdateView()
                    _view.ShowStatusMessage($"Расход '{description}' на сумму {amount:C} успешно добавлен.");
                }
                catch (InvalidOperationException ex) // Ошибка "Недостаточно средств" из Wallet.AddExpense
                {
                    _view.ShowStatusMessage($"Ошибка: {ex.Message}");
                }
                catch (ArgumentOutOfRangeException ex) // Ошибка из конструктора Transaction
                {
                    _view.ShowStatusMessage($"Ошибка: {ex.Message}");
                }
                catch (Exception ex) // Другие возможные ошибки
                {
                    _view.ShowStatusMessage($"Произошла ошибка при добавлении расхода: {ex.Message}");
                }
            }
            else
            {
                _view.ShowStatusMessage("Ошибка: Некорректная сумма. Введите положительное число.");
            }
        }

        /// <summary>
        /// Обновляет все элементы представления актуальными данными из модели.
        /// </summary>
        public void UpdateView()
        {
            // Форматируем баланс для отображения
            // Используем CultureInfo для корректного форматирования (точка/запятая как разделитель)
            string balanceStr = _wallet.Balance.ToString("N2", CultureInfo.CurrentCulture); // N2 - числовой формат с 2 знаками после запятой

            _view.UpdateBalanceLabel(balanceStr);
            _view.UpdateTransactionsList(_wallet.Transactions); // Передаем список транзакций
            // Можно сбросить статусное сообщение или оставить последнее
            // _view.ShowStatusMessage("Данные обновлены.");
        }


        /// <summary>
        /// Вспомогательный метод для безопасного парсинга суммы из строки.
        /// Проверяет, что число положительное.
        /// </summary>
        /// <param name="amountStr">Строка для парсинга.</param>
        /// <param name="amount">Результат парсинга (если успешно).</param>
        /// <returns>True, если парсинг успешен и число положительное, иначе False.</returns>
        private bool TryParseAmount(string amountStr, out decimal amount)
        {
            // Пытаемся распознать число с учетом текущей культуры (разделитель точка или запятая)
            if (decimal.TryParse(amountStr, NumberStyles.Any, CultureInfo.CurrentCulture, out amount))
            {
                // Проверяем, что сумма не отрицательная (0 - допустим, хотя и бессмысленно)
                if (amount >= 0)
                {
                    return true;
                }
            }
            amount = 0; // Сбрасываем значение, если парсинг неудачный
            return false;
        }
    }
}