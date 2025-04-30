using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChatBot
{
    internal class BotLogic
    {
        private List<Message> messageHistory = new List<Message>();
        private string userName;

        public string UserName // Добавляем публичное свойство
        {
            get { return userName; }
            set { userName = value; }
        }

        public BotLogic()
        {
            LoadHistory();
        }

        public string ProcessMessage(string input)
        {
            var message = new Message
            {
                Author = userName,
                Text = input,
                Timestamp = DateTime.Now
            };
            messageHistory.Add(message);

            return GenerateResponse(input);
        }

        private string GenerateResponse(string input)
        {
            input = input.ToLower();

            if (input == "привет, бот!")
                return "Привет, " + userName + "! Чем могу помочь?";

            if (input == "который час?")
                return $"Сейчас {DateTime.Now.ToString("HH:mm:ss")}";

            if (input == "статистика")
                return $"Всего сообщений: {messageHistory.Count}\n" +
                       $"От тебя: {messageHistory.Count(m => m.Author == userName)}";

            if (input.StartsWith("умножь"))
            {
                var parts = input.Split(' ');
                if (parts.Length == 4 && parts[2] == "на" &&
                    int.TryParse(parts[1], out int a) &&
                    int.TryParse(parts[3], out int b))
                {
                    return $"Результат: {a * b}";
                }
                return "Используй формат: умножь [число] на [число]";
            }

            return "Не понимаю команду. Попробуй: привет, бот!, который час?, статистика, умножь 12 на 157";
        }

        public void SetUserName(string name) => userName = name;

        private void LoadHistory()
        {
            if (File.Exists("history.txt"))
            {
                var lines = File.ReadAllLines("history.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        messageHistory.Add(new Message
                        {
                            Author = parts[0],
                            Timestamp = DateTime.Parse(parts[1]),
                            Text = parts[2]
                        });
                    }
                }
            }
        }

        public void SaveHistory()
        {
            var lines = messageHistory.Select(m => $"{m.Author}|{m.Timestamp}|{m.Text}");
            File.WriteAllLines("history.txt", lines);
        }
    }
}