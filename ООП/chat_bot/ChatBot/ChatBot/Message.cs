using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    internal class Message
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}