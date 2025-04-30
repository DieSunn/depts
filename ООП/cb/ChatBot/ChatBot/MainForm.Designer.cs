namespace ChatBot
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonChangeProfile = new System.Windows.Forms.Button();
            this.buttonClearChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBoxChat.Location = new System.Drawing.Point(10, 10);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.Size = new System.Drawing.Size(360, 400);
            this.richTextBoxChat.TabIndex = 0;
            this.richTextBoxChat.Text = "";
            // 
            // textBoxInput
            // 
            this.textBoxInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxInput.Location = new System.Drawing.Point(10, 420);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(360, 22);
            this.textBoxInput.TabIndex = 1;
            this.textBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxInput_KeyDown);
            // 
            // buttonChangeProfile
            // 
            this.buttonChangeProfile.Location = new System.Drawing.Point(261, 450);
            this.buttonChangeProfile.Name = "buttonChangeProfile";
            this.buttonChangeProfile.Size = new System.Drawing.Size(109, 30);
            this.buttonChangeProfile.TabIndex = 2;
            this.buttonChangeProfile.Text = "Сменить профиль";
            this.buttonChangeProfile.UseVisualStyleBackColor = true;
            this.buttonChangeProfile.Click += new System.EventHandler(this.buttonChangeProfile_Click);
            // 
            // buttonClearChat
            // 
            this.buttonClearChat.Location = new System.Drawing.Point(10, 450);
            this.buttonClearChat.Name = "buttonClearChat";
            this.buttonClearChat.Size = new System.Drawing.Size(100, 30);
            this.buttonClearChat.TabIndex = 3;
            this.buttonClearChat.Text = "Очистить чат";
            this.buttonClearChat.UseVisualStyleBackColor = true;
            this.buttonClearChat.Click += new System.EventHandler(this.buttonClearChat_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(384, 567);
            this.Controls.Add(this.buttonClearChat);
            this.Controls.Add(this.buttonChangeProfile);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.richTextBoxChat);
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonChangeProfile;
        private System.Windows.Forms.Button buttonClearChat;
    }
}

