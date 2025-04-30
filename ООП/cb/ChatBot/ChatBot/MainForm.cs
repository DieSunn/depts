using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChatBot
{
    // Главная форма чат-бота
    public partial class MainForm : Form
    {
        private BotLogic bot; // Экземпляр логики чат-бота

        // Конструктор формы, принимает имя пользователя
        public MainForm(string userName)
        {
            InitializeComponent();
            bot = new BotLogic();
            bot.SetUserName(userName); // Устанавливаем имя пользователя в боте
            LoadChatHistory(); // Загружаем историю чата
        }

        // Загружает историю сообщений в интерфейс
        private void LoadChatHistory()
        {
            richTextBoxChat.Clear();
            foreach (var message in bot.GetHistory())
            {
                string timestamp = message.Timestamp.ToString("HH:mm:ss");
                AppendColoredText(string.Format("[{0}] {1}: {2}\n", timestamp, message.Author, message.Text), message.Author);
            }
        }

        // Событие загрузки формы (не используется)
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        // Событие закрытия формы, сохраняет историю чата
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bot.SaveHistory();
        }

        // Добавляет текст в чат с цветовым оформлением в зависимости от автора
        private void AppendColoredText(string text, string author)
        {
            Color color;
            if (author == "Бот")
            {
                color = Color.DarkGreen;
            }
            else if (author == "[Система]")
            {
                color = Color.DarkBlue;
            }
            else
            {
                color = Color.Black; // Сообщения пользователя
            }

            richTextBoxChat.SelectionStart = richTextBoxChat.TextLength;
            richTextBoxChat.SelectionLength = 0;
            richTextBoxChat.SelectionColor = color;
            richTextBoxChat.AppendText(text);
            richTextBoxChat.SelectionColor = richTextBoxChat.ForeColor; // Сбрасываем цвет
        }

        // Обрабатывает нажатие клавиши в поле ввода
        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Control)
            {
                if (!string.IsNullOrEmpty(textBoxInput.Text))
                {
                    string userInput = textBoxInput.Text;
                    string response = bot.ProcessMessage(userInput);

                    // Обновляем интерфейс из истории, чтобы гарантировать синхронизацию
                    LoadChatHistory();

                    textBoxInput.Clear();
                }
                e.SuppressKeyPress = true; // Предотвращаем добавление символа новой строки
            }
        }

        // Кнопка смены профиля
        private void buttonChangeProfile_Click(object sender, EventArgs e)
        {
            bot.SaveHistory(); // Сохраняем историю перед сменой профиля
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    bot.SetUserName(loginForm.UserName);
                    AppendColoredText($"[Система] Профиль изменён на: {bot.UserName}\n", "[Система]");
                    LoadChatHistory();
                }
            }
        }

        // Кнопка очистки чата
        private void buttonClearChat_Click(object sender, EventArgs e)
        {
            bot.ProcessMessage("очистить"); // Вызываем очистку через бота
            richTextBoxChat.Clear();
            AppendColoredText("[Система] Чат очищен\n", "[Система]");
        }
    }
}