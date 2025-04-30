using System;
using System.Windows.Forms;
using System.Drawing;

namespace ChatBot
{
    public partial class MainForm : Form
    {
        private BotLogic bot;

        public MainForm(string userName)
        {
            InitializeComponent();
            bot = new BotLogic();
            bot.SetUserName(userName);
            LoadChatHistory();
        }

        private void LoadChatHistory()
        {
            richTextBoxChat.Clear();
            foreach (var message in bot.GetHistory())
            {
                string timestamp = message.Timestamp.ToString("HH:mm:ss");
                AppendColoredText(string.Format("[{0}] {1}: {2}\n", timestamp, message.Author, message.Text), message.Author);
            }
        }

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
                color = Color.Black;
            }

            richTextBoxChat.SelectionStart = richTextBoxChat.TextLength;
            richTextBoxChat.SelectionLength = 0;
            richTextBoxChat.SelectionColor = color;
            richTextBoxChat.AppendText(text);
            richTextBoxChat.SelectionColor = richTextBoxChat.ForeColor;
        }

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
                e.SuppressKeyPress = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bot.SaveHistory();
        }

        private void buttonChangeProfile_Click(object sender, EventArgs e)
        {
            bot.SaveHistory();
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    bot.SetUserName(loginForm.UserName);
                    AppendColoredText(string.Format("[Система] Профиль изменён на: {0}\n", bot.UserName), "[Система]");
                    LoadChatHistory();
                }
            }
        }

        private void buttonClearChat_Click(object sender, EventArgs e)
        {
            bot.ProcessMessage("очистить");
            richTextBoxChat.Clear();
            AppendColoredText("[Система] Чат очищен\n", "[Система]");
        }
    }
}