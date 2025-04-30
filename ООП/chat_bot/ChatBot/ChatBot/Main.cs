using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChatBot
{
    public partial class MainForm : Form
    {
        private BotLogic bot;
        private RichTextBox richTextBox1;
        private TextBox textBox1;

        public MainForm(string userName)
        {
            bot = new BotLogic();
            bot.SetUserName(userName);
            InitializeComponents(); // Изменил имя метода на более понятное
        }

        private void InitializeComponents()
        {
            // Настройки формы
            this.Size = new Size(400, 500);
            this.Text = "Текстовый квест";
            this.Font = new Font("Arial", 10);
            this.BackColor = Color.LightBlue;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += MainForm_FormClosing;

            // Создание RichTextBox для истории сообщений
            richTextBox1 = new RichTextBox
            {
                Location = new Point(10, 10),
                Size = new Size(360, 400),
                ReadOnly = true,
                BackColor = Color.WhiteSmoke
            };

            // Создание TextBox для ввода сообщений
            textBox1 = new TextBox
            {
                Location = new Point(10, 420),
                Size = new Size(360, 20),
                BackColor = Color.WhiteSmoke
            };
            textBox1.KeyDown += textBox1_KeyDown;

            // Добавление элементов на форму
            this.Controls.Add(richTextBox1);
            this.Controls.Add(textBox1);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Control)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    string userInput = textBox1.Text;
                    richTextBox1.AppendText($"{bot.UserName}: {userInput}\n");

                    string response = bot.ProcessMessage(userInput);
                    richTextBox1.AppendText($"Бот: {response}\n");

                    textBox1.Clear();
                }
                e.SuppressKeyPress = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bot.SaveHistory();
        }
    }
}