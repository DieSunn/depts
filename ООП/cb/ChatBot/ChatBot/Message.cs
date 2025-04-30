using System;

namespace ChatBot
{
    // Класс, представляющий сообщение в чате
    internal class Message
    {
        // Автор сообщения (пользователь или бот)
        public string Author { get; set; }

        // Текст сообщения
        public string Text { get; set; }

        // Временная метка сообщения
        public DateTime Timestamp { get; set; }
    }
}
