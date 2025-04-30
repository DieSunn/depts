using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChatBot
{
    // Класс, реализующий логику чат-бота
    internal class BotLogic
    {
        // История сообщений пользователя и бота
        private List<Message> messageHistory = new List<Message>();
        // Имя пользователя
        private string userName;

        // Свойство для доступа к имени пользователя
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        // Конструктор класса
        public BotLogic()
        {
        }

        // Обрабатывает входящее сообщение и возвращает ответ бота
        public string ProcessMessage(string input)
        {
            // Добавление сообщения пользователя в историю
            // message вместо var
            var userMessage = new Message
            {
                Author = userName,
                Text = input,
                Timestamp = DateTime.Now
            };
            messageHistory.Add(userMessage);

            // Генерация ответа бота
            string response = GenerateResponse(input);
            var botMessage = new Message
            {
                Author = "Бот",
                Text = response,
                Timestamp = DateTime.Now
            };
            messageHistory.Add(botMessage);

            return response;
        }

        // Генерирует ответ на основе входного сообщения
        private string GenerateResponse(string input)
        {
            input = input.ToLower();

            if (input == "привет, бот!")
                return "Привет, " + userName + "! Чем могу помочь?";

            if (input == "который час?")
                return "Сейчас " + DateTime.Now.ToString("HH:mm:ss");

            if (input == "статистика")
                return "Всего сообщений: " + messageHistory.Count + "\n" +
                       "От тебя: " + messageHistory.Count(m => m.Author == userName);

            if (input == "очистить")
            {
                messageHistory.Clear();
                SaveHistory();
                return "История чата очищена.";
            }

            if (input.StartsWith("покажи время в "))
            {
                string city = input.Replace("покажи время в ", "").Trim();
                return GetTimeForCity(city);
            }

            if (IsMathExpression(input))
            {
                try
                {
                    double result = EvaluateExpression(input);
                    return "Результат: " + result;
                }
                catch
                {
                    return "Ошибка в выражении. Пример: 12 * (5 + 3)";
                }
            }

            return "Не понимаю команду. Попробуй: привет, бот!, который час?, статистика, очистить, покажи время в [город], 12 * (5 + 3)";
        }

        // Возвращает текущее время в указанном городе
        private string GetTimeForCity(string city)
        {
            Dictionary<string, int> timeOffsets = new Dictionary<string, int>
            {
                { "москва", 3 },
                { "лондон", 0 },
                { "нью-йорк", -5 },
                { "Чита", 9 }
            };

            if (timeOffsets.ContainsKey(city))
            {
                DateTime utcTime = DateTime.UtcNow;
                DateTime cityTime = utcTime.AddHours(timeOffsets[city]);
                return "Время в " + city + ": " + cityTime.ToString("HH:mm:ss");
            }
            return "Не знаю такого города. Попробуй: Москва, Лондон, Нью-Йорк, Чита";
        }

        // Проверяет, является ли строка математическим выражением
        private bool IsMathExpression(string input)
        {
            string pattern = @"[\d]+.*[\+\-\*/\(\)]+.*[\d]+";
            return Regex.IsMatch(input, pattern);
        }

        // Вычисляет значение математического выражения
        private double EvaluateExpression(string expression)
        {
            expression = Regex.Replace(expression, @"\s+", "");
            while (expression.Contains("("))
            {
                int openBracket = expression.LastIndexOf("(");
                int closeBracket = expression.IndexOf(")", openBracket);
                if (closeBracket == -1) throw new Exception("Неправильные скобки");

                string subExpression = expression.Substring(openBracket + 1, closeBracket - openBracket - 1);
                double subResult = EvaluateSimpleExpression(subExpression);
                expression = expression.Substring(0, openBracket) + subResult + expression.Substring(closeBracket + 1);
            }

            return EvaluateSimpleExpression(expression);
        }

        // Вычисляет выражение без скобок, поддерживая сложение и умножение
        private double EvaluateSimpleExpression(string expression)
        {
            if (expression.Contains("+"))
            {
                var parts = expression.Split('+');
                double sum = 0;
                foreach (var part in parts)
                {
                    sum += EvaluateMultiplication(part);
                }
                return sum;
            }
            return EvaluateMultiplication(expression);
        }

        // Вычисляет произведение чисел в выражении
        private double EvaluateMultiplication(string expression)
        {
            if (expression.Contains("*"))
            {
                var parts = expression.Split('*');
                double product = 1;
                foreach (var part in parts)
                {
                    product *= double.Parse(part.Trim());
                }
                return product;
            }
            return double.Parse(expression.Trim());
        }

        // Устанавливает имя пользователя и загружает историю сообщений
        public void SetUserName(string name)
        {
            userName = name;
            LoadHistory();
        }

        // Загружает историю сообщений пользователя из файла
        private void LoadHistory()
        {
            messageHistory.Clear();
            string fileName = userName + "_history.txt";
            if (File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName);
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

        // Сохраняет историю сообщений пользователя в файл
        public void SaveHistory()
        {
            string fileName = userName + "_history.txt";
            var lines = new List<string>();
            foreach (var message in messageHistory)
            {
                lines.Add(string.Format("{0}|{1}|{2}", message.Author, message.Timestamp, message.Text));
            }
            File.WriteAllLines(fileName, lines);
        }

        // Возвращает историю сообщений
        public List<Message> GetHistory()
        {
            return messageHistory;
        }
    }
}
