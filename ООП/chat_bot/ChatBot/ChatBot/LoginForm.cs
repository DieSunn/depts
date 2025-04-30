using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChatBot
{
    public partial class LoginForm : Form
    {
        public string UserName { get; private set; }

        private TextBox textBox1;
        private Label label1;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(300, 150);
            this.Text = "Вход";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Arial", 10);
            this.BackColor = Color.LightBlue;
            this.StartPosition = FormStartPosition.CenterScreen;

            label1 = new Label
            {
                Text = "Введите имя:",
                Location = new Point(20, 20),
                Size = new Size(100, 20)
            };

            textBox1 = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(250, 20),
                BackColor = Color.WhiteSmoke
            };
            textBox1.KeyDown += LoginForm_KeyDown;

            this.Controls.Add(label1);
            this.Controls.Add(textBox1);
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(textBox1.Text))
            {
                UserName = textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}