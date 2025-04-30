using System.Collections.Generic;
using System.Globalization; // Для форматирования валюты
using System.Windows;
using VirtualWalletApp.Controllers;
using VirtualWalletApp.Models; // Нужно для Transaction

namespace VirtualWalletApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml (Представление - View).
    /// </summary>
    public partial class MainWindow : Window
    {
        // Ссылка на контроллер
        private readonly WalletController _controller;
        // Модель (в идеале View не должен знать о Model напрямую, но для простоты оставим)
        private readonly Wallet _wallet;

        public MainWindow()
        {
            InitializeComponent();

            // Создаем модель и контроллер при запуске окна
            _wallet = new Wallet();
            _controller = new WalletController(_wallet, this); // Передаем кошелек и само окно

            // Подписываемся на событие изменения кошелька из модели,
            // чтобы обновлять UI автоматически при изменениях.
            _wallet.WalletChanged += Wallet_WalletChanged;

            // Инициализация отображения при запуске
            _controller.UpdateView();
        }

        /// <summary>
        /// Обработчик события изменения кошелька. Вызывается, когда в модели что-то поменялось.
        /// </summary>
        private void Wallet_WalletChanged(object sender, System.EventArgs e)
        {
            // Обновляем UI из потока UI, если изменения пришли из другого потока (на всякий случай)
            Dispatcher.Invoke(() => {
                _controller.UpdateView(); // Просим контроллер обновить вид
            });
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить доход".
        /// </summary>
        private void AddIncomeButton_Click(object sender, RoutedEventArgs e)
        {
            // Передаем данные из полей ввода контроллеру
            _controller.AddIncome(AmountTextBox.Text, DescriptionTextBox.Text);
            // Очищаем поля ввода после добавления
            ClearInputFields();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить расход".
        /// </summary>
        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            // Передаем данные из полей ввода контроллеру
            _controller.AddExpense(AmountTextBox.Text, DescriptionTextBox.Text);
            // Очищаем поля ввода после добавления
            ClearInputFields();
        }

        /// <summary>
        /// Обновляет метку с балансом на форме.
        /// Вызывается контроллером.
        /// </summary>
        /// <param name="balance">Новое значение баланса в виде строки.</param>
        public void UpdateBalanceLabel(string balance)
        {
            // Используем CultureInfo для корректного отображения знака валюты
            BalanceLabel.Content = $"{balance} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
            // BalanceLabel.Content = $"{balance} руб."; // Или так, если проще
        }

        /// <summary>
        /// Обновляет список транзакций на форме.
        /// Вызывается контроллером.
        /// </summary>
        /// <param name="transactions">Коллекция транзакций для отображения.</param>
        public void UpdateTransactionsList(IEnumerable<Transaction> transactions)
        {
            // Простое добавление строк (можно улучшить с ItemsSource и Data Binding)
            TransactionsListBox.Items.Clear();
            foreach (var transaction in transactions)
            {
                TransactionsListBox.Items.Add(transaction.ToString()); // Используем переопределенный ToString
            }
        }

        /// <summary>
        /// Отображает сообщение об ошибке или статус в строке состояния.
        /// Вызывается контроллером.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void ShowStatusMessage(string message)
        {
            StatusTextBlock.Text = message;
        }

        /// <summary>
        /// Очищает поля ввода суммы и описания.
        /// </summary>
        private void ClearInputFields()
        {
            AmountTextBox.Clear();
            DescriptionTextBox.Clear();
            // Устанавливаем фокус обратно на поле суммы для удобства
            AmountTextBox.Focus();
        }
    }
}