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
    // Форма для ввода имени пользователя перед началом работы с чат-ботом
    public partial class LoginForm : Form
    {
        // Свойство для хранения имени пользователя
        public string UserName { get; set; }

        // Конструктор формы
        public LoginForm()
        {
            InitializeComponent();
        }

        // Событие загрузки формы (пока не используется)
        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        // Событие изменения текста в поле ввода (пока не используется)
        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
        }

        // Обрабатывает нажатие клавиши в поле ввода
        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            // Если нажата клавиша Enter и поле не пустое
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(textBoxUserName.Text))
            {
                UserName = textBoxUserName.Text; // Устанавливаем значение свойства
                this.DialogResult = DialogResult.OK; // Завершаем форму с успешным результатом
                this.Close(); // Закрываем форму
            }
        }
    }
}
